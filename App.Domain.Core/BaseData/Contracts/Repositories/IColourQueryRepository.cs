using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColourQueryRepository
    {
       Task<ColourDto?> Get(string name);
        Task<ColourDto?> Get(int id);
    }
}
