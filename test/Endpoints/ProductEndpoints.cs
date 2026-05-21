using test.DTO;
using test.Services;

namespace test.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products");

            group.MapGet("/", async (IProductService productService) =>
            {
                var products = await productService.GetProductsAsync();
                return Results.Ok(products);
            });

            group.MapPost("/", async (CreateProductDto dto, IProductService productService) =>
            {
                try
                {
                    var result = await productService.CreateProductAsync(dto);
                    return Results.Created($"/api/products/{result.Id}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }
    }
}
