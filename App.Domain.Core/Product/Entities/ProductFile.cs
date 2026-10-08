using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;
public partial class ProductFile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductId { get; set; }

    public int FileTypeId { get; set; }

    public string Path { get; set; } = null!;


    public virtual FileType FileType { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
