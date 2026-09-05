using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class Colour
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<ProductColour> ProductColours { get; set; } = new List<ProductColour>();
}
