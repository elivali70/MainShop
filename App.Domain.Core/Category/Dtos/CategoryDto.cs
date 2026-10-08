
namespace App.Domain.Core.Category.Entities;

public partial class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public bool IsActive { get; set; }

    public int DisplayOrder { get; set; }

}
