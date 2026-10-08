using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services.BaseData
{
    public class ColourService : IColourService
    {
        private readonly IColourQueryRepository _colourQueryRepository;

        public ColourService(IColourQueryRepository colourQueryRepository)
        {
            _colourQueryRepository = colourQueryRepository;
        }
        public async Task<int> Get(string name)
        {
           var Colour= await _colourQueryRepository.Get(name);
            return Colour.Id;
        }
    }
}
