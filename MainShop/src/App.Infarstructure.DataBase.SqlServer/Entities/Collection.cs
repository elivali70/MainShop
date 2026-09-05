using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class Collection
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<CollectionProduct> CollectionProducts { get; set; } = new List<CollectionProduct>();
}
