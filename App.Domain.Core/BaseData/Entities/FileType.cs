using App.Domain.Core.BaseData.Enums;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities;

public partial class FileType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ValidExtentions { get; set; }

    public  FileTypeEnum Type { get; set; }
    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
}
