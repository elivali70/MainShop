using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductQueryRepository
    {
        Task<List<ProductBriefDto>?> Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken);
        Task<List<ProductDto>?> GetAll();
        Task<ModelDto?> GetModel(string modelName);
        Task<int> Get(string name);
    }
}

