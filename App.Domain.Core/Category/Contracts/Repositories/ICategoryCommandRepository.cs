using App.Domain.Core.Category.Entities;

public interface ICategoryCommandRepository
{
    Task Add(string name,int displayOrder,int? parentCategoryId,bool isActive);
    Task Remove(int id);
    Task Edit(int id,string name, int displayOrder, int? parentCategoryId,bool isActive);
}