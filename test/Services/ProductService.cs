using test.DTO;
using test.Entities;
using test.Repositories;

namespace test.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Price));
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            // Regola di business / Validazione
            if (dto.Price < 0) throw new ArgumentException("Il prezzo non può essere negativo.");

            var product = new Product { Name = dto.Name, Price = dto.Price };
            await _repository.AddAsync(product);

            return new ProductDto(product.Id, product.Name, product.Price);
        }
    }
}
