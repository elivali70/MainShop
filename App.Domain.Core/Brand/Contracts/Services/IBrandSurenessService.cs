

namespace App.Domain.Core.Brand.Contracts.Services
{
    public interface IBrandSurenessService
    {
        Task EnsureBrandIsNotExist(int brandId);
        Task EnsureBrandIsNotExist(string brandName);
        Task EnsureBrandIsExist(int brandId);
        Task EnsureBrandIsExist(string brandName);
    }
}
