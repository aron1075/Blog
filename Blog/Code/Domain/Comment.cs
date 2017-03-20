using System;

namespace Code {

 public class Comment {

    public Comment() {
        CreatedOn = DateTime.Now;
    }

    public int CommentId { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }

}

}
    