using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Brand.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.Domain.Services.BaseData;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Data.Contract.Service;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Brand;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Category;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IBrandAppService _brandAppService;

        public ProductController(IProductAppService productAppService, IFileStorageService fileStorageService, IBrandAppService brandAppService)
        {
            _productAppService = productAppService;
            _fileStorageService = fileStorageService;
            _brandAppService = brandAppService;
        }
        public async Task<IActionResult> Index()
        {
            var Products = await _productAppService.GetAll();
            return View(Products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()

        {
            int operatorId = 5;
            var brand = await _brandAppService.GetAll(operatorId);
            ViewBag.brandOutPut = brand.Select(x => new BrandOutPutViewModel()
            {
               Name=x.Name,
                Id=x.Id,
            }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductInPutViewModel product)
        {

            if (ModelState.IsValid)
            {
                var colours = product.Colours?.Select(c => new ColourDto()
                {
                    Name = c,
                }).ToList();
                var files = product.Files?.Select(f => new ProductFileInputDto()
                {
                    Name = f.FileName,
                    Content = f.OpenReadStream(),
                    Type = f.ContentType,
                }).ToList();
                var productInput = new ProductInputDto()
                {
                    Name = product.Name,
                    Files = files,
                    Colours = colours,
                    IsOriginal = product.IsOriginal,
                    BrandId = product.BrandId,
                    CategoryName = product.CategoryName,
                    Count = product.Count,
                    Discription = product.Discription,
                    Price = product.Price,
                    Weight = product.Weight,
                };
                var productId = await _productAppService.Set(productInput);
                await _productAppService.SetProductColour(productId, product.Colours);
                //change and take them to appservice
                var path = await _fileStorageService.CreateProductFolder(productId);

                var productPath =await _fileStorageService.SaveFile(files, path);

                //
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
