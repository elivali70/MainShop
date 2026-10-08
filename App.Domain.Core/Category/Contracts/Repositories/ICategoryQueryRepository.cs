
using App.Domain.Core.Category.Entities;


namespace App.Domain.Core.Category.Contracts.Repositories
{
    public interface ICategoryQueryRepository
    {
      
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task<CategoryDto?> Get(string name);
    }
}
 