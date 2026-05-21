using test.DTO;

namespace test.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    }
}
