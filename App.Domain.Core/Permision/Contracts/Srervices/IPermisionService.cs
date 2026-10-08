using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Permision.Contracts.Srervices
{
    public interface IPermisionService
    {
       Task <bool> HasPermision(int operatorId, int permisionId );
    }
}
