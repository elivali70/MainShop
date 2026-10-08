using App.Domain.Core.Product.Dtos;
using App.EndPoint.Mvc.ShopUI.Areas.Admin.Data.Contract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services.BaseData
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> CreateProductFolder(int id)
        {
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "upload", "product", id.ToString());
            Directory.CreateDirectory(folderPath);
            return folderPath;

        }

        public async Task<List<string>> SaveFile(List<ProductFileInputDto> files, string folderPath)
        {
            var path= new List<string>();
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.Name);
                var fileName=$"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(folderPath, fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.Content.CopyToAsync(stream);
                path.Add(filePath);
            }
            return path;
        }
    }
}
