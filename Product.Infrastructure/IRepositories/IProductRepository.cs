using System.Threading.Tasks;
using Product.Infrastructure.Dto;

namespace Product.Infrastructure.IRepositories
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductById(int id);

        public Task Add(ProductDto dto);

        public Task Update(ProductDto dto);

        public Task Delete(int id);
    }
}
