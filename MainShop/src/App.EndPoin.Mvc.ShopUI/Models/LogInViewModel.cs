using System.ComponentModel.DataAnnotations;

public class LogInViewModel
{
    [Display(Name = "ایمیل")]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(maximumLength: 20, ErrorMessage = "{0}کلمه عبور حداقل {1} کارکتر و حداکثر {2} کارکتر باشد", MinimumLength = 6)]
    [Display(Name = "رمز عبور")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "مرا بخاطر بسپار")]
    public bool RememberMe { get; set; }

}