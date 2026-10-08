using App.Domain.Core.Brand.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Brand.Dtos;
using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class BrandQueryRepository : IBrandQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public BrandQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<BrandDto>> GetAll()
        {
            var brands = await _appDbContext.Brands.AsNoTracking().Select(s => new BrandDto()
            {
                Id = s.Id,
                Name = s.Name,
                DisplayOrder = s.DisplayOrder,

            }).ToListAsync();
            return brands;
        }

        public async Task<BrandDto?> Get(string name)
        {
            var brand = await _appDbContext.Brands.AsNoTracking().Where(x => x.Name == name).Select(x => new BrandDto
            {
                Name = x.Name,
                DisplayOrder = x.DisplayOrder,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            }).SingleOrDefaultAsync();
            return brand;
        }
        public async Task<BrandDto?> Get(int id)
        {
            var brand = await _appDbContext.Brands.AsNoTracking().Where(x => x.Id == id).Select(x => new BrandDto
            {
                Name = x.Name,
                DisplayOrder = x.DisplayOrder,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            }
             ).FirstOrDefaultAsync();

            return brand;
        }

    }
}
