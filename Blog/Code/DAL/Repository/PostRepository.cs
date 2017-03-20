using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Code {

public class PostRepository : Repository<Post>, IPostRepository {

    public PostRepository(BlogDbContext aContext) : base(aContext) {
        // void
    }

    public IEnumerable<Post> GetPosts() {
        var posts = mEntity
            .Include(e => e.Comments)
            .OrderByDescending(e => e.CreatedOn);

        return posts;
    }


    public Post GetPost(int aPostId) {
        var post = mEntity
            .Where(e => e.PostId == aPostId)
            .Include(e => e.Comments).First();

        return post;
    }

}

}
