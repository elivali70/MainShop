using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Brand
{
    public class BrandOutPutViewModel
    {
      
        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }

        [Display(Name = "نام برند")]
        public string Name { get; set; } = null!;

        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted {  get; set; }
    }
}
