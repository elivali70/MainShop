using System;
using System.Collections.Generic;
using App.Domain.Core.Brand.Entities;

namespace App.Domain.Core.Product.Entities;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public int? ParentModelId { get; set; }

    public int ProductId { get; set; }

    public virtual Brand.Entities.Brand Brand { get; set; } = null!;

    public virtual Product? Product { get; set; }

    public virtual ICollection<Model> InverseParentModel { get; set; } = new List<Model>();

    public virtual Model? ParentModel { get; set; }







}
