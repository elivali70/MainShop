using System;
using System.Collections.Generic;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.BaseData.Entities;

public partial class SubmitOperator
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<App.Domain.Core.Product.Entities.Product> Products { get; set; } = new List<App.Domain.Core.Product.Entities.Product>();
}
