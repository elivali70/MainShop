using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Brand.Contracts.AppServices;
using App.Domain.Core.Brand.Contracts.Services;
using App.Domain.Core.Category.Contracts.Services;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IColourService _colourService;

        public ProductAppService(IProductService productService, ICategoryService categoryService, IBrandService brandService,IColourService colourService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _colourService = colourService;
        }

        public async Task<List<ProductDto>?> GetAll()
        {
            var producrts = await _productService.GetAll();
            return producrts;
        }

        public async Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            return await _productService.GetProducts(categoryId, keyWord, minPrice, maxPrice, brandId, cancellationToken);
        }
        public async Task<int> Set(ProductInputDto productInputDto)
        {
            var categoryId = await _categoryService.Get(productInputDto.CategoryName);

            var productId = await _productService.Set(productInputDto.Name, categoryId, productInputDto.BrandId,
                productInputDto.Discription, productInputDto.IsOriginal, productInputDto.IsShowPrice,
                productInputDto.Price, productInputDto.Count, productInputDto.Weight);
            return productId;
        }
        public async Task SetProductColour(int productId,List<string> colourName)
        {
            foreach (var colour in colourName)
            {
               int colourId= await _colourService.Get(colour);
                await _productService.SetProductColour(productId, colourId);
            }
           
        }
        public async Task SetProductFile(int productId,ProductFileInputDto files)
        {

        }
    }
}
