using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class ProductColour
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColourId { get; set; }

    public bool IsExist { get; set; }

    public virtual Colour Colour { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
