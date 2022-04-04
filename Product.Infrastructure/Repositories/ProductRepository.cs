using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Context;
using Product.Infrastructure.Dto;
using Product.Infrastructure.IRepositories;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _db;
        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task Add(ProductDto dto)
        {
            await _db.Products.AddAsync(dto);
            await _db.SaveChangesAsync();

        }

        public async Task Update(ProductDto dto)
        {
            _db.Products.Update(dto);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = _db.Products
               .Where(s => s.Id == id)
               .FirstOrDefault();

            _db.Entry(product).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }
    }
}
