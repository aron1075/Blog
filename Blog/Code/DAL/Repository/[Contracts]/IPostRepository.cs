using System.Collections.Generic;

namespace Code {

public interface IPostRepository : IRepository<Post> {

    IEnumerable<Post> GetPosts();
    Post GetPost(int aPostId);

}

}
