using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;

public interface IProductCommandRepository
{
    Task Add(string name, int categoryId, int brandId, string? Discription, bool IsOriginal, bool isShowPrice, int price, int count, decimal? Weight);
    Task AddProductColour(int productId, int colourId, bool isExist);
}