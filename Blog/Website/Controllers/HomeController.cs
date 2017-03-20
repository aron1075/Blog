using Code;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog {

public class HomeController : Controller {

    IAccountService mAccountService;
    IPostService mPostService;
    IAwsService mAwsService;
   
    public HomeController(IAccountService aAccountService, IPostService aPostService, IAwsService aAwsService) {
        mAccountService = aAccountService;
        mPostService = aPostService;
        mAwsService = aAwsService;
    }

    [AllowAnonymous]
    public ActionResult Index() {
        var posts = mPostService.GetPosts();
        var model = new PostsViewModel();

        foreach (var post in posts) {
            var postModel = new PostViewModel() {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CreateOn = post.CreatedOn               
            };

            foreach (var comment in post.Comments) {
                postModel.Comments.Add(new CommentViewModel() { Content = comment.Content, CreatedOn = comment.CreatedOn });
            }

            if (post.PhotoAwsKey != null) {
                postModel.FileStream = mAwsService.GetFile(post.PhotoAwsKey);
            }
            model.Posts.Add(postModel);
        }

        return View(model);
    }

    [AllowAnonymous]
    public ActionResult ViewPost(int aPostId) {
        var post = mPostService.GetPost(aPostId);
        var model = new PostViewModel() {
            PostId = post.PostId,
            Title = post.Title,
            Content = post.Content,
            CreateOn = post.CreatedOn
        };

        foreach (var comment in post.Comments) {
            model.Comments.Add(new CommentViewModel() { Content = comment.Content, CreatedOn = comment.CreatedOn });
        }

        if (post.PhotoAwsKey != null) {
            model.FileStream = mAwsService.GetFile(post.PhotoAwsKey);
        }

        return View(model);
    }

    [Authorize]
    public ActionResult AddPost() {
        return View();
    }

    [HttpPost]
    public ActionResult AddPost(PostViewModel aModel) {
        if (ModelState.IsValid) {
            var account = mAccountService.GetAccount(Request.GetUserDataCookie().AccountId);
            var post = new Post() {
                Title = aModel.Title,
                Content = aModel.Content,
                AccountId = account.AccountId
            };

            post = mPostService.AddPost(post, aModel.FileStream);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [Authorize]
    public ActionResult AddComment(int aPostId) {
        TempData["PostId"] = aPostId;
        return View();
    }

    [HttpPost]
    public ActionResult AddComment(CommentViewModel aModel) {
        if (ModelState.IsValid) {
            var comment = new Comment() {
                PostId = (int)TempData["PostId"],
                Content = aModel.Content
            };

            comment = mPostService.AddComment(comment);
            return RedirectToAction("ViewPost", "Home", new { aPostId = comment.PostId });
        }
        return View();
    }

    [HttpPost]
    [ChildActionOnly]
    public ActionResult UploadFile(HttpPostedFile aFile) {
        if (aFile != null) {
            var fileStream = aFile.InputStream;
        }
        return null;
    }

}

} // namespace
