using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Dto;

namespace Product.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<ProductDto> Products { get; set; }
    }
}
