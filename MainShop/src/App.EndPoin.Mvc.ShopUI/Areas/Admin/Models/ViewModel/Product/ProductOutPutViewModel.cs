using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Product
{
    public class ProductOutPutViewModel
    {
        [Display(Name = " شناسه")]
        [ReadOnly(true)]
        public int Id { get; set; }

        [Display(Name = "نام *")]
        public string Name { get; set; } = null!;

        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }

        [Display(Name = " برند *")]
        public string BrandName { get; set; }

        [Display(Name = " وزن")]
        public decimal? Weight { get; set; }

        [Display(Name = " اصالت کالا")]
        public bool IsOriginal { get; set; }

        [Display(Name = " توضیحات")]
        public string? Discription { get; set; }

        [Display(Name = " تعداد *")]
        public int Count { get; set; }

        [Display(Name = " مدل")]
        public string? ModelName { get; set; }

        [Display(Name = " قیمت")]
        public int Price { get; set; }

        [Display(Name = " رنگبندی")]
        public List<string>? Colours { get; set; }

        [Display(Name = " فایل")]
        public List<ProductFileOutPutViewModel>? Files { get; set; }
    }
}
