using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infarstructure.DataBase.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class ColourCommandRepository : IColourCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ColourCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(string name, string code)
        {
            var colour = new Colour()
            {
                Name = name,
                Code = code
            };
            await _appDbContext.AddAsync(colour);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
