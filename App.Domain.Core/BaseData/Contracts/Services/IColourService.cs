using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IColourService
    {
     Task<int> Get(string name);
    }
}
