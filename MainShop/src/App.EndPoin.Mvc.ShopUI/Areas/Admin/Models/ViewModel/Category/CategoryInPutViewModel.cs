using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Category
{
    public class CategoryInPutViewModel
    {
        [Display(Name = " شناسه")]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; } = null!;
        [Display(Name = "شناسه دسته بندی اصلی")]
        public int? ParentCategoryId { get; set; }
      
        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "تعیین ترتیب نمایش اجباری است")]
        [Range(1, 5, ErrorMessage = "مقدار باید بین 1 تا 5 باشد")]
        public int DisplayOrder { get; set; }
        [Display(Name = "دسته بندی اصلی")]
        public List<CategoryOutPutViewModel> ParentCategories { get; set; } = new();
    }
}
