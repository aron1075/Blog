using Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace Blog {

public class PostViewModel {

    public PostViewModel() {
        Comments = new List<CommentViewModel>();
    }

    public int PostId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreateOn { get; set; }

    [MaxLength(50)]
    public string PhotoAwsKey { get; set; }

    public Stream FileStream { get; set; }

    public List<CommentViewModel> Comments { get; set; }

}

}