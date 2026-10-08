using App.Domain.Core.Category.Contracts.AppServices;
using App.Domain.Core.Category.Contracts.Services;
using App.Domain.Core.Category.Entities;
using App.Domain.Core.Permision.Contracts.Srervices;
using App.Domain.Core.Permision.Enums;
using System.Data;

namespace App.Domain.AppServices.Category
{

    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IPermisionService _permisionService;
        private readonly ICategorySurenessService _categorySurenessService;

        public CategoryAppService(ICategoryService categoryService, IPermisionService permisionService, ICategorySurenessService categorySurenessService)
        {
            _categoryService = categoryService;
            _permisionService = permisionService;
            _categorySurenessService = categorySurenessService;
        }

        public async Task<CategoryDto?> Get(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.ViewCategory);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _categorySurenessService.EnsureCategoryIsExist(id);
            return await _categoryService.Get(id);
        }

        public async Task<List<CategoryDto>> GetAll(int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.ViewCategory);
            if (!hasPermision)
                throw new UnauthorizedAccessException();
            return await _categoryService.GetAll();
        }
        public async Task<CategoryDto?> GetForDelete(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.RemoveCategory);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _categorySurenessService.EnsureCategoryIsExist(id);
            return await _categoryService.Get(id);
        }

        public async Task Delete(int id, int operatorId)
        {
        
            await _categoryService.Delete(id);
        }
        public async Task<CategoryDto?> GetForUpdate(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.UpdateCategory);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _categorySurenessService.EnsureCategoryIsExist(id);
            return await _categoryService.Get(id);
        }
        public async Task Update(int id, string name, int displayOrder,int? parentCategoryId, bool isActive)
        {
            await _categorySurenessService.EnsureCategoryIsExist(name);
            await _categoryService.Update(id, name, displayOrder, parentCategoryId,isActive);

        }


        public async Task Set(string name, int displayOrder, int? parentCategoryId, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.AddCategory);
            if (!hasPermision)
                throw new Exception("You Cant access to add Brand");
            await _categorySurenessService.EnsureCategoryIsNotExist(name);
            await _categoryService.Set(name, displayOrder,parentCategoryId);
        }

    }
}