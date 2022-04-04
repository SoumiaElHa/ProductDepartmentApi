
using System.Threading.Tasks;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IProductService
    {
        Task CreateOrUpdate(ProductEntity product);

        Task Delete(int id);
    }
}
