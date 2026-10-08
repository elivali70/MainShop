using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public decimal? Weight { get; set; }

        public bool IsOriginal { get; set; }

        public string? Discription { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        public bool IsShowPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime SubmitTime { get; set; }

        public int SubmitOperatorId { get; set; }

        public List<ColourDto>? Colours { get; set; }
        public List<ProductFileDto>? Files { get; set; }


    }
}
