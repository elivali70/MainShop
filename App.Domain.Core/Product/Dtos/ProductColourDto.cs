using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;

public partial class ProductColourDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColourId { get; set; }

    public bool IsExist { get; set; }


}
