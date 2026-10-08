using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Product
{
    public class ProductInPutViewModel
    {
        [Display(Name = " شناسه")]
        [ReadOnly(true)]
        public int Id { get; set; }

        [Display(Name = "نام *")]
        [Required(ErrorMessage = "تعیین نام محصول اجباری است")]
        public string Name { get; set; } = null!;

        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }

        [Display(Name = " برند *")]
        [Required(ErrorMessage = "تعیین نام برند اجباری است")]
        public int BrandId { get; set; }

        [Display(Name = " وزن")]
        public decimal? Weight { get; set; }

        [Display(Name = " اصالت کالا")]
        public bool IsOriginal { get; set; }

        [Display(Name = " توضیحات")]
        public string? Discription { get; set; }

        [Display(Name = " تعداد *")]
        [Required(ErrorMessage = "تعیین تعداد کالا اجباری است")]
        [Range(2, 20, ErrorMessage = "مقدار باید بین 2 تا 20 باشد")]
        public int Count { get; set; }

        [Display(Name = " قیمت *")]
        [Range(1, int.MaxValue, ErrorMessage = "قیمت باید بزرگ‌تر از صفر باشد")]
        public int Price { get; set; }

        [Display(Name = " رنگبندی")]
        public List<string>? Colours { get; set; }

        [Display(Name = " فایل")]
        public List<IFormFile>? Files { get; set; }
        [Display(Name = " نمایش قیمت")]
        public bool IsShowPrice { get; set; }
    }
}
