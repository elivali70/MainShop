using App.Domain.Core.Product.Contracts.AppServices;
using App.EndPoint.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductAppService _productAppService;

        public SearchController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet]
        public async Task<IActionResult> List(int? categoryId, string keyWord,CancellationToken cancellationToken)
        {
          var products= await _productAppService.GetProducts(categoryId, keyWord,null,null,null, cancellationToken);
            if(products == null)
            {
               
            }
            else
            {
               var viewModel= products.Select(p => new SearchViewModel()
                {
                    ProductId=p.Id,
                    Name=p.Name,
                    BrandName=p.BrandName,
                    CategoryName=p.CategoryName,
                    Colours=p.colours?.Select(c=>c.Name).ToList(),
                    Count=p.Count,
                    Price=p.Price.ToString(),
                    IsOriginal=p.IsOriginal,
                    ImageUrls=p.Files?.Where(p=>p.FileTypeId==2).Select(p=>"/pics/"+p.Name).ToList(),
                    VideoUrls=p.Files?.Where(p=>p.FileTypeId==1).Select(p=> "/videos/"+p.Name).ToList(),

                }).ToList();
            return View(viewModel);
            }
            return View();
        }
    }
}
