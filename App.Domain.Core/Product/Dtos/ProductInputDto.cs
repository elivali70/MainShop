using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Dtos
{

    public class ProductInputDto
    {
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int BrandId { get; set; }
        public decimal? Weight { get; set; }
        public bool IsOriginal { get; set; }
        public string? Discription { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public bool IsShowPrice { get; set; }
        public List<ColourDto>? Colours { get; set; }
        public List<ProductFileInputDto>? Files { get; set; }
    }
}
