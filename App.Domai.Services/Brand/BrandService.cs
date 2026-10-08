using App.Domain.Core.Brand.Contracts.Repositories;
using App.Domain.Core.Brand.Contracts.Services;
using App.Domain.Core.Brand.Dtos;
using App.Domain.Core.Brand.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

    public class BrandService : IBrandService
    {
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly IBrandCommandRepository _brandCommandRepository;

        public BrandService(IBrandQueryRepository brandQueryRepository, IBrandCommandRepository brandCommandRepository)
        {
            _brandQueryRepository = brandQueryRepository;
           _brandCommandRepository = brandCommandRepository;
        }

        public async Task Set(string name, int displayOrder)
        {
            bool isDeleted=false;
            DateTime dateTime=DateTime.Now;
            await _brandCommandRepository.Add(name,displayOrder,dateTime,isDeleted);
        }
        public async Task<List<BrandDto>> GetAll()
        {
            return  await _brandQueryRepository.GetAll();
        }
        public async Task<BrandDto?> Get(int id)
        {
            return await _brandQueryRepository.Get(id);
        }
        public async Task Delete(int id)
        { 

           await _brandCommandRepository.Remove(id);
        }

        public async Task Update(int id,string name, int displayOrder, bool isDeleted)
        {

           await _brandCommandRepository.Edit(id, name, displayOrder, isDeleted);
        }

    public async Task<int> GetId(string name)
    {
       var brandDto= await _brandQueryRepository.Get(name);
        int id = brandDto.Id;
        return id;
    }
}