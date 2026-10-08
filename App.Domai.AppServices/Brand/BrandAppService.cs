using App.Domain.Core.Brand.Contracts.AppServices;
using App.Domain.Core.Brand.Contracts.Services;
using App.Domain.Core.Brand.Dtos;
using App.Domain.Core.Permision.Contracts.Srervices;
using App.Domain.Core.Permision.Enums;
using System.Data;

namespace App.Domain.AppServices.Brand
{

    public class BrandAppService : IBrandAppService
    {
        private readonly IBrandService _brandService;
        private readonly IPermisionService _permisionService;
        private readonly IBrandSurenessService _brandSurenessService;

        public BrandAppService(IBrandService brandService, IPermisionService permisionService, IBrandSurenessService brandSurenessService)
        {
            _brandService = brandService;
            _permisionService = permisionService;
            _brandSurenessService = brandSurenessService;
        }

        public async Task<BrandDto?> Get(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.ViewBrands);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _brandSurenessService.EnsureBrandIsExist(id);
            return await _brandService.Get(id);
        }

        public async Task<List<BrandDto>> GetAll(int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.ViewBrands);
            if (!hasPermision)
                throw new UnauthorizedAccessException();
            return await _brandService.GetAll();
        }
        public async Task<BrandDto?> GetForDelete(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.RemoveBrands);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _brandSurenessService.EnsureBrandIsExist(id);
            return await  _brandService.Get(id);
        }

        public async Task Delete(int id, int operatorId)
        {
           
            await _brandService.Delete(id);
        }
        public async Task<BrandDto?> GetForUpdate(int id, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.UpdateBrands);
            if (!hasPermision)
                throw new Exception("You Cant See This Page");
            await _brandSurenessService.EnsureBrandIsExist(id);
            return await _brandService.Get(id);
        }

        public async Task Set(string name, int displayOrder, int operatorId)
        {
            var hasPermision = await _permisionService.HasPermision(operatorId, (int)PermisionEnum.AddBrands);
            if (!hasPermision)
                throw new Exception("You Cant access to add Brand");
            await _brandSurenessService.EnsureBrandIsNotExist(name);
            await _brandService.Set(name, displayOrder);
        }
        public async Task Update(int id, string name, int displayOrder, bool isDeleted)
        {
            await _brandSurenessService.EnsureBrandIsExist(name);
            await _brandService.Update(id, name, displayOrder, isDeleted);

        }

        public async  Task<int> GetId(string name)
        {
            return await _brandService.GetId(name);
        }
    }
}