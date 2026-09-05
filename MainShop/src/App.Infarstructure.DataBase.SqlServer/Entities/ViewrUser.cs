using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class ViewrUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();
}
