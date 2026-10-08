using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColourCommandRepository
    {
        Task Add(string name, string code);
    }
}
