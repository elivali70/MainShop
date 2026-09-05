using System;
using System.Collections.Generic;

namespace App.Infarstructure.DataBase.SqlServer.Entities;

public partial class ProductView
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime Viewtime { get; set; }

    public int ViewerUserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ViewrUser ViewerUser { get; set; } = null!;
}
