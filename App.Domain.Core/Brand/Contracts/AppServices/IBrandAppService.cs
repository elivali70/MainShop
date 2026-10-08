using App.Domain.Core.Brand.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Brand.Contracts.AppServices
{
    public interface IBrandAppService
    {
        Task<List<BrandDto>> GetAll(int operatorId);
        Task<BrandDto?> Get(int id,int operatorId);
        Task Set(string name, int displayOrder,int operatorId);
        Task Delete(int id,int operatorId);
        Task<BrandDto?> GetForDelete(int id, int operatorId);
        Task<BrandDto?> GetForUpdate(int id, int operatorId);
        Task Update(int id,string name,int displayOrder,bool isDeleted);
        Task<int> GetId(string name);

    }
}
