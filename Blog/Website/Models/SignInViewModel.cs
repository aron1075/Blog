using System.ComponentModel.DataAnnotations;

namespace Blog {

public class SignInViewModel {

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    [MaxLength(10)]
    public string Password { get; set; }

}

}