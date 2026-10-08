using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(string name, int categoryId, int brandId, string? Discription, bool IsOriginal, bool isShowPrice, int price, int count, decimal? Weight)
        {
          
            var product = new Product();
            product.Name = name;
            product.CategoryId = categoryId;
            product.BrandId = brandId;
            product.Count = count;
            product.Price = price;
            product.Weight = Weight;
            product.IsOriginal = IsOriginal;
            product.IsShowPrice = isShowPrice;
            product.Discription = Discription;
            product.SubmitOperatorId = 1;
           
           await _appDbContext.AddAsync(product);
            await _appDbContext.SaveChangesAsync();

        }
        public async Task AddProductColour(int productId,int colourId,  bool isExist)
        {
            var ProductColour=new ProductColour();
            ProductColour.ProductId = productId;
            ProductColour.ColourId = colourId;
            ProductColour.IsExist = isExist;
            await _appDbContext.AddAsync(ProductColour);
            await _appDbContext.SaveChangesAsync();

        }
    }
}
