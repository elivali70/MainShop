using App.Domain.Core.Category;
using App.Domain.Core.Category.Entities;


namespace App.Domain.Core.Category.Contracts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetAll(int operatorId);
        Task<CategoryDto?> Get(int id,int operatorId);
        Task Set(string name, int displayOrder,int? parentCategoryId,int operatorId);
        Task Delete(int id,int operatorId);
        Task<CategoryDto?> GetForDelete(int id, int operatorId);
        Task<CategoryDto?> GetForUpdate(int id, int operatorId);
        Task Update(int id,string name,int displayOrder,int? parentCategoryId,bool isActive);

    }
}
