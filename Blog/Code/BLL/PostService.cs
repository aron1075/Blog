using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Code {

public class PostService : IPostService {

    IUnitOfWork mUnitOfWork;
    IAwsService mAwsService;

    public PostService(IUnitOfWork aUnitOfWork, IAwsService aAwsService) {
        mUnitOfWork = aUnitOfWork;
        mAwsService = aAwsService;
    }

    public Post AddPost(Post aPost, Stream aFileStream = null) {
        if (aFileStream != null) {
            aPost.PhotoAwsKey = mAwsService.UploadFile(aFileStream);
        }

        var post = mUnitOfWork.Post.Add(aPost);
        mUnitOfWork.Commit();

        return post;
    }  

    public Post GetPost(int aPostId) {
        var post = mUnitOfWork.Post.GetPost(aPostId);
        return post;
    }

    public List<Post> GetPosts() {
        var posts = mUnitOfWork.Post.GetPosts();
        return posts.ToList();
    }

    public Comment AddComment(Comment aComment) {
        var comment = mUnitOfWork.Comment.Add(aComment);
        mUnitOfWork.Commit();
        return comment;
    }

}

}
