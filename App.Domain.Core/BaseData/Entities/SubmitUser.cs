using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities;

public partial class SubmitUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
