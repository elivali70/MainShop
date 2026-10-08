using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken);
        Task Set(string name, int categoryId, int brandId, int count, string colour, int price, string? Discription, bool IsOriginal);
        Task<List<ProductDto>?> GetAll();
        Task<ProductDto?> Get(int id);
        Task<ProductDto?> Get(string name);
        Task<int> GetModelId(string modelName);
        Task<int> Set(string name, int categoryId, int brandId, string? Discription, bool IsOriginal, bool isShowPrice, int price, int count,decimal? Weight);
         Task SetProductColour(int productId, int colourId);
        //Task SetSecondaryField(int id);
        //Task SetFiles(int id, ProductFileDto fileDto);
    }
}
