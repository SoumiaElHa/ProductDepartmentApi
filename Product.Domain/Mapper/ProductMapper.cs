using Product.Domain.Entities;
using Product.Infrastructure.Dto;

namespace Product.Domain.Mapper
{
    public static class ProductMapper
    {

        public static ProductEntity ProductDtoToProductEntity(this ProductDto dto)
        {
            if (dto == null) return null;

            return new ProductEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }

        public static ProductDto ProductEntityToProductDto(this ProductEntity entity)
        {
            if (entity == null) return null;

            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}
