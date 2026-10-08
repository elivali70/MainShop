using App.Domain.Core.Permision.Contracts.Repositories;
using App.Domain.Core.Permision.Contracts.Srervices;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infarstructure.DataBase.SqlServer.Repository
{
    public class PermisionRepository : IPermisionRepository
    {
        public List<int> GetOperatorPermisions(int operatorId)
        {
            List<int> permisions = new();
            permisions.Add(1);
            permisions.Add(2);
            permisions.Add(5);
            return permisions;

        }


    }
}
