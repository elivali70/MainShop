using App.Domain.Core.Category.Contracts.Repositories;
using App.Domain.Core.Category.Contracts.Services;

namespace App.Domain.Services.Category
{
    public class CategorySurenessService : ICategorySurenessService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public CategorySurenessService(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task EnsureCategoryIsNotExist(string name)
        {
           var category= await _categoryQueryRepository.Get(name);
            if (category != null)
                 throw new Exception("category is  exist");
        }

       public async Task EnsureCategoryIsNotExist(int id)
        {
            var category = await _categoryQueryRepository.Get(id);
            if (category != null)
                throw new Exception("category is  exist");
        }
        public async Task EnsureCategoryIsExist(string name)
        {
            var category = await _categoryQueryRepository.Get(name);
            if (category == null)
                throw new Exception("category is not exist");
        }
        public async Task EnsureCategoryIsExist(int id)
        {
            var category = await _categoryQueryRepository.Get(id);
            if (category == null)
                throw new Exception("category is not exist");
        }

    }
       
}
