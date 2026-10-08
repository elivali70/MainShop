using App.Domain.Core.Category.Entities;

namespace App.Domain.Core.Category.Contracts.Services
{
    public interface ICategoryService
    {
       Task<List<CategoryDto>> GetAll();
        Task Set(string name,int displayOrder, int? parentCategoryId);
        Task<CategoryDto?> Get(int id);
        Task<int> Get(string name);
        Task Delete(int id);
        Task Update(int id, string name, int displayOrder, int?  parentCategoryId,bool isActive);
    }
}
