using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class Barnd
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual ICollection<Model> ModelBrandId1Navigations { get; set; } = new List<Model>();

    public virtual ICollection<Model> ModelBrands { get; set; } = new List<Model>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
