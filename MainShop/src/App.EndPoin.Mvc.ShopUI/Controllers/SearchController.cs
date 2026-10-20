using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoint.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace App.EndPoint.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IConfiguration _configuration;

        public SearchController(IProductAppService productAppService,IConfiguration configuration)
        {
            _productAppService = productAppService;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> List(int? categoryId, string keyWord,CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var request= new HttpRequestMessage(HttpMethod.Get, "http://localhost:5136/api/Product/GetProduct"+$"/?categoryId={categoryId}$keyWord={keyWord}");
            request.Headers.Add("ApiKey",_configuration.GetSection("ApiKey").Value);
            var response= await client.SendAsync(request,cancellationToken);
            var responseBody= await response.Content.ReadAsStringAsync();
            var responseBodyModel=JsonConvert.DeserializeObject<List<ProductBriefDto>>(responseBody);
            if( responseBodyModel == null )
            {

            }
            if(response.IsSuccessStatusCode == false )
            {
                throw new Exception("خطا در دریافت اطلاعات");
            }
            else
            {
                var viewModel = responseBodyModel.Select(x => new SearchViewModel()
                {
                    ProductId  = x.Id,
                    BrandName = x.BrandName,
                    CategoryName = x.CategoryName,
                    Name = x.Name,
                    Colours =x.colours?.Select(c=>c.Name).ToList(),
                    Price =x.Price is null ? null: x.Price.ToString(),
                    Count = x.Count,
                    IsOriginal = x.IsOriginal,
                    ImageUrls =x.Files is null?null: x.Files?.Where(x => x.FileTypeId == 2).Select(x => "/pics/" + x.Name).ToList(),
                    VideoUrls = x.Files is null? null:x.Files?.Where(x => x.FileTypeId == 1).Select(x => "/videos/" + x.Name).ToList(),
                }).ToList();
                return View(viewModel);
            }
          //var products= await _productAppService.GetProducts(categoryId, keyWord,null,null,null, cancellationToken);
          //  if(products == null)
          //  {
               
          //  }
          //  else
          //  {
          //     var viewModel= products.Select(p => new SearchViewModel()
          //      {
          //          ProductId=p.Id,
          //          Name=p.Name,
          //          BrandName=p.BrandName,
          //          CategoryName=p.CategoryName,
          //          Colours=p.colours?.Select(c=>c.Name).ToList(),
          //          Count=p.Count,
          //          Price=p.Price.ToString(),
          //          IsOriginal=p.IsOriginal,
          //          ImageUrls=p.Files?.Where(p=>p.FileTypeId==2).Select(p=>"/pics/"+p.Name).ToList(),
          //          VideoUrls=p.Files?.Where(p=>p.FileTypeId==1).Select(p=> "/videos/"+p.Name).ToList(),

          //      }).ToList();
          //  return View(viewModel);
          //  }
          //  return View();
        }
    }
}
