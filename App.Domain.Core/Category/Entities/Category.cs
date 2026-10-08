using System;
using System.Collections.Generic;
using App.Domain.Core.Product.Entities;
namespace App.Domain.Core.Category.Entities;
public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public bool IsActive { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Product.Entities.Product> Products { get; set; } = new List<Product.Entities.Product>();
}
