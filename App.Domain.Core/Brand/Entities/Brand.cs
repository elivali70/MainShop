using App.Domain.Core.Product.Entities;


namespace App.Domain.Core.Brand.Entities;

public  class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }
    public DateTime CreationDate {  get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<Model> ModelBrandId1Navigations { get; set; } = new List<Model>();

    public virtual ICollection<Model> ModelBrands { get; set; } = new List<Model>();

    public virtual ICollection<Product.Entities.Product> Products { get; set; } = new List<Product.Entities.Product>();
}
