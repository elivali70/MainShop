using App.Domain.Core.BaseData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductFileInputDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; }
        public Stream Content { get; set; } = null!;

    }
}
