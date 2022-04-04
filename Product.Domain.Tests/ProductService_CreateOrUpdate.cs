using System.Threading.Tasks;
using Moq;
using Product.Domain.Entities;
using Product.Domain.Services;
using Product.Infrastructure.Dto;
using Xunit;

namespace Product.Domain.Tests
{
    public class ProductService_CreateOrUpdate : TestBase
    {
        [Fact]
        public void CreateOrUpdate_ExistingProduct()
        {
            var dto = new ProductDto
            {
                Id=1,
                Name = "test123"
            };

            var entity = new ProductEntity
            {
                Id = 1,
                Name = "test123"
            };
            ProductDto expectedReturn = new ProductDto
            {
                Id = 1,
                Name = "test"
            };
            MockIProductRepository.Setup(x => x.GetProductById(entity.Id))
                                        .Returns(Task.FromResult(expectedReturn));
            MockIProductRepository.Setup(x => x.Add(dto));

            var service = new ProductService(MockIProductRepository.Object);
            var result = service.CreateOrUpdate(entity);

            MockIProductRepository.Verify(x => x.GetProductById(entity.Id));
            MockIProductRepository.Verify(x => x.Update(It.IsAny<ProductDto>()));

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateOrUpdate_NewProduct()
        {
            var dto = new ProductDto
            {
                Name="test"
            };

            var entity = new ProductEntity
            {
                Name = "test"
            };
            ProductDto expectedReturn = null;           
            MockIProductRepository.Setup(x => x.GetProductById(entity.Id))
                                        .Returns(Task.FromResult(expectedReturn));
            MockIProductRepository.Setup(x => x.Add(dto));

            var service = new ProductService(MockIProductRepository.Object);
            var result = service.CreateOrUpdate(entity);

            MockIProductRepository.Verify(x => x.GetProductById(entity.Id));
            MockIProductRepository.Verify(x => x.Add(It.IsAny<ProductDto>()));

            Assert.NotNull(result);
           
        }
      
    }
}
