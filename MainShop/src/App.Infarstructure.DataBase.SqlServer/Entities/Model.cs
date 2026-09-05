using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public int? ParentModelId { get; set; }

    public int? BrandId1 { get; set; }

    public virtual Barnd Brand { get; set; } = null!;

    public virtual Barnd? BrandId1Navigation { get; set; }

    public virtual ICollection<Model> InverseParentModel { get; set; } = new List<Model>();

    public virtual Model? ParentModel { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
