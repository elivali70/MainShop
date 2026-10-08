

namespace App.Domain.Core.Brand.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int DisplayOrder { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
