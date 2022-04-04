using Moq;
using Product.Infrastructure.IRepositories;

namespace Product.Domain.Tests
{
    public class TestBase
    {
        protected readonly Mock<IProductRepository> MockIProductRepository;

        public TestBase()
        {
            MockIProductRepository = new Mock<IProductRepository>();
        }
    }
}
