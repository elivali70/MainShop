using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool ForComment { get; set; }

    public bool ForProduct { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
