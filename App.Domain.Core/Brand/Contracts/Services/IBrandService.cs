using App.Domain.Core.Brand.Dtos;

namespace App.Domain.Core.Brand.Contracts.Services
{
    public interface IBrandService
    {
       Task<List<BrandDto>> GetAll();
        Task Set(string name,int displayOrder);
        Task<BrandDto?> Get(int id);
        Task Delete(int id);
        Task Update(int id, string name, int displayOrder, bool isDeleted);
        Task<int> GetId(string name);
    }
}
