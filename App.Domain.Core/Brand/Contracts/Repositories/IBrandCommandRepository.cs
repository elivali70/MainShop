using App.Domain.Core.Brand.Entities;

public interface IBrandCommandRepository
{
    Task Add(string name, int displayOrder, DateTime creationDate, bool isDeleted);
    Task Remove(int id);
    Task Edit(int id, string name, int displayOrder,bool isDeleted);
}