using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.UserManager
{
    public class UserViewModel
    {
        [Display(Name ="شناسه کاربر")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="نام")]
        public string Name {  get; set; }

        [Display(Name = "ایمیل")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="شماره تماس")]
        public string PhoneNumber {  get; set; }

    }
}
