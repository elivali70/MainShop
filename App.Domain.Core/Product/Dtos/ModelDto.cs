using System;
using System.Collections.Generic;
using App.Domain.Core.Brand.Entities;

namespace App.Domain.Core.Product.Entities;

public partial class ModelDto
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public int? ParentModelId { get; set; }

    public int ProductId { get; set; }

}
