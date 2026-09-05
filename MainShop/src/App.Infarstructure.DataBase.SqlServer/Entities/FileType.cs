using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class FileType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ValidExtentions { get; set; }

    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
}
