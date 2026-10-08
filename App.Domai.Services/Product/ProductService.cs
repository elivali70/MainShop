using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository;

        public ProductService(IProductQueryRepository productQueryRepository,IProductCommandRepository productCommandRepository)
        {
            _productQueryRepository = productQueryRepository;
           _productCommandRepository = productCommandRepository;
        }

        public Task Set(string name, int categoryId, int brandId, int count, string colour, int price, string? Discription, bool IsOriginal)
        {
            throw new NotImplementedException();
        }

        public  async Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            return await _productQueryRepository.Search(categoryId, keyWord, minPrice, maxPrice, brandId, cancellationToken);
        }

        public async Task<List<ProductDto>?> GetAll()
        {
            var products=await _productQueryRepository.GetAll();
            return products;
        }

        public Task<ProductDto?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetModelId(string modelName)
        {
            
           var modelDto= await _productQueryRepository.GetModel(modelName);
            int modelId = modelDto.Id;
                return modelId;
        }


        public async Task<int> Set(string name, int categoryId, int brandId, string? Discription, bool IsOriginal, bool isShowPrice, int price, int count, decimal? Weight)
        {

            await _productCommandRepository.Add(name, categoryId, brandId, Discription, IsOriginal, isShowPrice, price, count, Weight);
           var id=  await _productQueryRepository.Get(name);
            return id;
        }
        public async Task SetProductColour(int productId,int colourId)
        {
            bool isExist=true;
            await _productCommandRepository.AddProductColour(productId, colourId,isExist);
        }
        
    }
}
