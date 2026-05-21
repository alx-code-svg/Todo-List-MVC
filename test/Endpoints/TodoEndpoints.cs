using test.DTO;
using test.Services;

namespace test.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/todos");

            // READ (Ottieni tutti i Todo)
            group.MapGet("/", async (ITodoService todoService) =>
                Results.Ok(await todoService.GetAllTodosAsync()));

            // CREATE (Aggiungi un Todo)
            group.MapPost("/", async (CreateTodoDto dto, ITodoService todoService) =>
            {
                try
                {
                    var result = await todoService.CreateTodoAsync(dto);
                    return Results.Created($"/api/todos/{result.Id}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            // UPDATE (Modifica o spunta come completato)
            group.MapPut("/{id:int}", async (int id, UpdateTodoDto dto, ITodoService todoService) =>
            {
                var updated = await todoService.UpdateTodoAsync(id, dto);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE (Elimina un Todo)
            group.MapDelete("/{id:int}", async (int id, ITodoService todoService) =>
            {
                var deleted = await todoService.DeleteTodoAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
