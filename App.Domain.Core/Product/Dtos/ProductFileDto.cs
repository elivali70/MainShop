using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.BaseData.Enums;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Dtos;
public partial class ProductFileDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductId { get; set; }

    public int FileTypeId { get; set; }
    public string Path { get; set; } = null!;

    public  FileTypeDto FileType { get; set; } = null!;

}
