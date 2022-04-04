using System.Threading.Tasks;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using Product.Domain.Mapper;
using Product.Infrastructure.IRepositories;

namespace Product.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task CreateOrUpdate(ProductEntity product)
        {

            var productToAdd = await _productRepository.GetProductById(product.Id);
            if (productToAdd == null)
            {
                await _productRepository.Add(product.ProductEntityToProductDto());
            }
            else
            {
                await _productRepository.Update(product.ProductEntityToProductDto());
            }
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
