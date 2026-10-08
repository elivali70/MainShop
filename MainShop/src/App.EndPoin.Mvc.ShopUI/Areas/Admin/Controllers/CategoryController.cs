using App.Domain.Core.Category.Contracts.AppServices;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.WebSockets;
namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var operatorId = 5;
            var categories = await _categoryAppService.GetAll(operatorId);
            var categoryModel = categories.Select(p => new CategoryOutPutViewModel()
            {
                IsActive = p.IsActive,
                DisplayOrder = p.DisplayOrder,
                Name = p.Name,
                ParentCategoryId = p.ParentCategoryId,
                Id = p.Id,
               
            }).ToList();
            return View(categoryModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            int operatorId = 5;
            var category = await _categoryAppService.GetForDelete(id, operatorId);
            var categorModel = new CategoryOutPutViewModel();
            categorModel.Id = category.Id;
            categorModel.IsActive = category.IsActive;
            categorModel.DisplayOrder = category.DisplayOrder;
            categorModel.Name = category.Name;
            categorModel.ParentCategoryId = category.ParentCategoryId;
            return View(categorModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryOutPutViewModel category)
        {
            int operatorId = 5;
            var id = category.Id;
            await _categoryAppService.Delete(id, operatorId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            int operatorId = 5;
            var category = await _categoryAppService.GetForUpdate(id, operatorId);
            var categories = await _categoryAppService.GetAll(operatorId);
            var categorModel = new CategoryOutPutViewModel();
            categorModel.Id = category.Id;
            categorModel.DisplayOrder = category.DisplayOrder;
            categorModel.Name = category.Name;
            categorModel.ParentCategoryId = category.ParentCategoryId;
            categorModel.IsActive = category.IsActive;
            categorModel.ParentCategories=categories.Select(p=> new CategoryOutPutViewModel(){
               Id= p.Id,
               Name= p.Name,
            }).ToList();
            return View(categorModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryOutPutViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryAppService.Update(category.Id, category.Name, category.DisplayOrder, category.ParentCategoryId, category.IsActive);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<IActionResult> Detail(int id)
        {
            int operatorId = 5;
            var category = await _categoryAppService.Get(id, operatorId);
            var categoryModel = new CategoryOutPutViewModel();
            categoryModel.Id = category.Id;
            categoryModel.IsActive = category.IsActive;
            categoryModel.DisplayOrder = category.DisplayOrder;
            categoryModel.Name = category.Name;
            categoryModel.ParentCategoryId = category.ParentCategoryId;
            return View(categoryModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryInPutViewModel category)
        {
            
            if (ModelState.IsValid)
            {
                int operatorId = 5;
                await _categoryAppService.Set(category.Name, category.DisplayOrder,category.ParentCategoryId, operatorId);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
