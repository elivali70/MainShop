using App.Domain.Core.Category.Contracts.Repositories;

using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.Category.Entities;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var category = await _appDbContext.Categories.AsNoTracking().Select(s => new CategoryDto()
            {
                Id = s.Id,
                Name = s.Name,
                DisplayOrder = s.DisplayOrder,
                ParentCategoryId = s.ParentCategoryId,
                IsActive = s.IsActive,

            }).ToListAsync();
            return category;
        }

        public async Task<CategoryDto?> Get(string name)
        {
            var category = await _appDbContext.Categories.AsNoTracking().Where(x => x.Name == name).Select(x => new CategoryDto()
            {
                Name = x.Name,
                DisplayOrder = x.DisplayOrder,
                Id = x.Id,
                IsActive = x.IsActive,
                ParentCategoryId= x.ParentCategoryId,
            }).SingleOrDefaultAsync();
            return category;
        }
        public async Task<CategoryDto?> Get(int id)
        {
            var category = await _appDbContext.Categories.AsNoTracking().Where(x => x.Id == id).Select(x => new CategoryDto
            {
                Name = x.Name,
                DisplayOrder = x.DisplayOrder,
                Id = x.Id,
                IsActive = x.IsActive,
                ParentCategoryId= x.ParentCategoryId,
            }
             ).FirstOrDefaultAsync();

            return category;
        }

    }
}
