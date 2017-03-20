using System.Collections.Generic;
using System.IO;

namespace Code {

public interface IPostService {
        
    Post AddPost(Post aPost, Stream aFileStream = null);

    Post GetPost(int aPostId);

    List<Post> GetPosts();

    Comment AddComment(Comment aComment);

}

}
