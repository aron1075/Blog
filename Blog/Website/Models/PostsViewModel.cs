using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog {

public class PostsViewModel {

    public PostsViewModel() {
        Posts = new List<PostViewModel>();
    }

    public List<PostViewModel> Posts { get; set; }

}

}