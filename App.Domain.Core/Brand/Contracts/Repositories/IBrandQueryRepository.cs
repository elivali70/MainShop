using App.Domain.Core.Brand.Dtos;
using App.Domain.Core.Brand.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Brand.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
      
        Task<List<BrandDto>> GetAll();
        Task<BrandDto?> Get(int id);
        Task<BrandDto?> Get(string name);
    }
}
 