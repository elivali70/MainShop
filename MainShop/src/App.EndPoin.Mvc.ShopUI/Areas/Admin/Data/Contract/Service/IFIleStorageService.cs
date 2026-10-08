using App.Domain.Core.Product.Dtos;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Data.Contract.Service
{
   
        public interface IFileStorageService
        {
            Task<string> CreateProductFolder(int id);
        Task<List<string>> SaveFile(List<ProductFileInputDto> files, string folderPath);

        }
    }
