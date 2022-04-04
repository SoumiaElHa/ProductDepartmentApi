using System.ComponentModel.DataAnnotations;

namespace Product.Infrastructure.Dto
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
