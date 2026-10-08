using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Permision.Contracts.Repositories
{
    public interface IPermisionRepository
    {
       List<int> GetOperatorPermisions(int operatorIs);
    }
}
