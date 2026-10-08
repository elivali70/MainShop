using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.Product.Entities
{


    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal? Weight { get; set; }

        public bool IsOriginal { get; set; }

        public string? Discription { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        public bool IsShowPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime SubmitTime { get; set; }

        public int SubmitOperatorId { get; set; }

        public int StatusId { get; set; }

        public virtual List<Model> Models { get; set; }
        
        public virtual Brand.Entities.Brand Brand { get; set; } = null!;

        public virtual Category.Entities.Category Category { get; set; } = null!;

        public virtual ICollection<CollectionProduct> CollectionProducts { get; set; } = new List<CollectionProduct>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();


        public virtual ICollection<ProductColour> ProductColours { get; set; } = new List<ProductColour>();

        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();

        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

        public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();

        public virtual SubmitOperator SubmitOperator { get; set; } = null!;
    }


}