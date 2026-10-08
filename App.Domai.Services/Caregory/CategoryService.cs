using App.Domain.Core.Category.Contracts.Repositories;
using App.Domain.Core.Category.Contracts.Services;

using App.Domain.Core.Category.Entities;

namespace App.Domain.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public CategoryService(ICategoryQueryRepository categoryQueryRepository, ICategoryCommandRepository categoryCommandRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
           _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task Set(string name, int displayOrder, int? parentCategoryId)
        {
            bool isActive = true;
            await _categoryCommandRepository.Add(name, displayOrder,parentCategoryId,isActive);
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            return await _categoryQueryRepository.GetAll();
        }
        public async Task<CategoryDto?> Get(int id)
        {
            return await _categoryQueryRepository.Get(id);
        }
        public async Task Delete(int id)
        {

            await _categoryCommandRepository.Remove(id);
        }

        public async Task Update(int id, string name, int displayOrder, int? parentCategoryId, bool isActive)
        {

            await _categoryCommandRepository.Edit(id, name, displayOrder, parentCategoryId,isActive);
        }

        public async Task<int> Get(string name)
        {
          var categoryDto= await _categoryQueryRepository.Get(name);
            var categoryId = categoryDto.Id;
            return categoryId;
        }
    }
}
