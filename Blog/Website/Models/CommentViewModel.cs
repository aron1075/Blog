using System;
using System.ComponentModel.DataAnnotations;

namespace Blog {

public class CommentViewModel {

    public int PostId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }
}

}