using App.Domain.Core.Permision.Contracts.Repositories;
using App.Domain.Core.Permision.Contracts.Srervices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Services.Permision
{
    public class PermisionService : IPermisionService
    {
        private readonly IPermisionRepository _permisionRepository;

        public PermisionService(IPermisionRepository permisionRepository)
        {
            _permisionRepository = permisionRepository;
        }
        public async Task<bool> HasPermision(int operatorId, int permisionId)
        {
            //if (operatorId == 1)
                return true;
            //var operatorPermision = _permisionRepository.GetOperatorPermisions(operatorId);
            //return operatorPermision.Any(x => x == permisionId);
        }
    }
}
