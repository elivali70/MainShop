

namespace App.Domain.Core.Category.Contracts.Services
{
    public interface ICategorySurenessService
    {
        Task EnsureCategoryIsNotExist(int id);
        Task EnsureCategoryIsNotExist(string name);
        Task EnsureCategoryIsExist(int Id);
        Task EnsureCategoryIsExist(string name);
    }
}
