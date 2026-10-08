using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class ColourQueryRepository : IColourQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ColourQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ColourDto?> Get(string name)
        {
           return await _appDbContext.Colours.AsNoTracking().Where(x => x.Name == name).Select(x => new ColourDto()
            {
                Name = x.Name,
                Code = x.Code,
                Id = x.Id,

            }).SingleOrDefaultAsync();
        }

        public async Task<ColourDto?> Get(int id)
        {
            return await _appDbContext.Colours.AsNoTracking().Where(x => x.Id == id).Select(x => new ColourDto()
            {
                Name = x.Name,
                Code = x.Code,
                Id = x.Id,

            }).SingleOrDefaultAsync();
        }
    }
}
