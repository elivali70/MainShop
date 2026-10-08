using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken);
        Task<List<ProductDto>?> GetAll();

        Task<int> Set(ProductInputDto productInputDto);
        Task SetProductColour(int productId, List<string> colourName);
        Task SetProductFile(int productId, ProductFileInputDto files);
    }
}