using App.Domain.Core.Brand.Contracts.AppServices;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Brand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.WebSockets;
namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var operatorId = 5;
            var brands = await _brandAppService.GetAll(operatorId);
            var brandModel = brands.Select(p => new BrandOutPutViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(brandModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            int operatorId = 5;
            var brand = await _brandAppService.GetForDelete(id, operatorId);
            var brandModel = new BrandOutPutViewModel();
            brandModel.Id = brand.Id;
            brandModel.IsDeleted = brand.IsDeleted;
            brandModel.DisplayOrder = brand.DisplayOrder;
            brandModel.Name = brand.Name;
            brandModel.CreationDate = brand.CreationDate;
            return View(brandModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BrandOutPutViewModel brand)
        {
            int operatorId = 5;
            var id = brand.Id;
            await _brandAppService.Delete(id, operatorId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            int operatorId = 5;
            var brand = await _brandAppService.GetForUpdate(id, operatorId);
            var brandModel = new BrandOutPutViewModel();
            brandModel.Id = brand.Id;
            brandModel.DisplayOrder = brand.DisplayOrder;
            brandModel.Name = brand.Name;
            return View(brandModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BrandOutPutViewModel brand)
        {
            if (ModelState.IsValid)
            {
            await _brandAppService.Update(brand.Id, brand.Name, brand.DisplayOrder, brand.IsDeleted);
            return RedirectToAction("Index");
            }
            return View(brand);
        }
        public async Task<IActionResult> Detail(int id)
        {
            int operatorId = 5;
            var brand = await _brandAppService.Get(id, operatorId);
            var brandModel = new BrandOutPutViewModel();
            brandModel.Id = brand.Id;
            brandModel.IsDeleted = brand.IsDeleted;
            brandModel.DisplayOrder = brand.DisplayOrder;
            brandModel.Name = brand.Name;
            brandModel.CreationDate = brand.CreationDate;
            return View(brandModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandInPutViewModel brand)
        {
            if (ModelState.IsValid && brand.Name.ToLower() == "hp" && brand.DisplayOrder > 2)
                ModelState.AddModelError("", "برند hp باید در ابتدای لیست قرار بگیرد ");
            if (ModelState.IsValid)
            {
            int operatorId = 5;
            await _brandAppService.Set(brand.Name, brand.DisplayOrder, operatorId);
            return RedirectToAction("Index");
            }
            return View(brand);
        }
    }
}
