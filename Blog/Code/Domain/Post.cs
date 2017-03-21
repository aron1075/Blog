using System;
using System.Collections.Generic;

namespace Code {

public class Post {

    public Post() {
        Comments = new List<Comment>();
        CreatedOn = DateTime.Now;
    }

    public int PostId { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string FileKey { get; set; }

    public DateTime CreatedOn { get; set; }

    public List<Comment> Comments { get; set; }
}

}
    