namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Product
{
    public class ProductFileOutPutViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ValidExtentions { get; set; }
        public FileTypeEnumViewModel Type { get; set; } 

    }
}