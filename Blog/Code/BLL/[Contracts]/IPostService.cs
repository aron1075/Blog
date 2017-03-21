using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Code {

public interface IPostService {
        
    Post AddPost(Post aPost, HttpPostedFileBase aFile = null);

    Post GetPost(int aPostId);

    List<Post> GetPosts();

    Comment AddComment(Comment aComment);

}

}
