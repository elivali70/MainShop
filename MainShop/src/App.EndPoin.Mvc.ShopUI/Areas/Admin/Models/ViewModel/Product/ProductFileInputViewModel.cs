using App.Domain.Core.BaseData.Enums;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Product
{
    public class ProductFileInputViewModel
    {
        public IFormFile File { get; set; }

        public FileTypeEnum Type { get; set; }
    }
}
