using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Get(string name)
        {
            return await _appDbContext.Products.AsNoTracking().Where(x => x.Name == name).Select(x => x.Id).SingleOrDefaultAsync();

        }

        public async Task<List<ProductDto>?> GetAll()
        {
            var products = await _appDbContext.Products.AsNoTracking().Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                BrandName = p.Brand.Name,
                Colours = p.ProductColours.Select(c => new ColourDto()
                {
                    Id = c.Colour.Id,
                    Name = c.Colour.Name,
                    Code = c.Colour.Code,
                }).ToList(),
                Count = p.Count,
                Discription = p.Discription,
                Files = p.ProductFiles.Select(f => new ProductFileDto()
                {
                    Id = f.Id,
                    Name = f.Name,
                    FileType = new FileTypeDto()
                    {
                        Id = f.FileType.Id,
                        Name = f.FileType.Name,
                        Type = f.FileType.Type
                    },
                    ProductId = f.ProductId,
                    FileTypeId = f.FileTypeId,

                }).ToList(),
                IsActive = p.IsActive,
                IsOriginal = p.IsOriginal,
                IsShowPrice = p.IsShowPrice,
                SubmitTime = p.SubmitTime,
                Price = p.Price,
                SubmitOperatorId = p.SubmitOperatorId,
                Weight = p.Weight,
            }).ToListAsync();
            return products;
        }

        public async Task<ModelDto?> GetModel(string modelName)
        {
            return await _appDbContext.Models.AsNoTracking().Where(x => x.Name == modelName).Select(m => new ModelDto()
            {
                Name = m.Name,
                Id = m.Id,
                ParentModelId = m.ParentModelId,
                BrandId = m.BrandId,
            }).SingleOrDefaultAsync();
        }

        public async Task<List<ProductBriefDto>?> Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.AsNoTracking()
                .Where(p => (categoryId == null || p.CategoryId == categoryId))
                .Where(p => (minPrice == null || p.Price >= minPrice))
                .Where(p => (maxPrice == null || p.Price <= maxPrice))
                .Where(p => (brandId == null || p.BrandId == brandId))
                .Where(p => (keyWord == null || keyWord == "" || p.Discription.Contains(keyWord) || p.Name.Contains(keyWord)))
                .Select(p => new ProductBriefDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandName = p.Brand.Name,
                    CategoryName = p.Category.Name,
                    Price = p.Price,
                    IsOriginal = p.IsOriginal,
                    Count = p.Count,
                    colours = p.ProductColours.Select(c => new ColourDto()
                    {
                        Id = c.ColourId,
                        Name = c.Colour.Name,
                        Code = c.Colour.Code,
                    }).ToList(),

                    Files = p.ProductFiles.Select(f => new ProductFileDto()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        FileType = new FileTypeDto()
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Type = f.FileType.Type

                        },
                        ProductId = f.ProductId,
                        FileTypeId = f.FileTypeId,

                    }).ToList(),

                }).ToListAsync(cancellationToken);

        }
    }
}
