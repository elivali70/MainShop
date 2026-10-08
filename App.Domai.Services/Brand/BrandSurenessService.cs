using App.Domain.Core.Brand.Contracts.Repositories;
using App.Domain.Core.Brand.Contracts.Services;
namespace App.Domain.Services.Brand
{
    public class BrandSurenessService : IBrandSurenessService
    {
        private readonly IBrandQueryRepository _brandQueryRepository;

        public BrandSurenessService(IBrandQueryRepository brandQueryRepository)
        {
            _brandQueryRepository = brandQueryRepository;
        }

        public async Task EnsureBrandIsNotExist(string brandName)
        {
           var brand= await _brandQueryRepository.Get(brandName);
            if (brand!= null)
                 throw new Exception("brand is  exist");
        }

       public async Task EnsureBrandIsNotExist(int brandId)
        {
            var brand = await _brandQueryRepository.Get(brandId);
            if (brand != null)
                throw new Exception("brand is  exist");
        }
        public async Task EnsureBrandIsExist(string brandName)
        {
            var brand = await _brandQueryRepository.Get(brandName);
            if (brand == null)
                throw new Exception("brand is not exist");
        }
        public async Task EnsureBrandIsExist(int brandId)
        {
            var brand = await _brandQueryRepository.Get(brandId);
            if (brand == null)
                throw new Exception("brand is not exist");
        }

    }
       
}
