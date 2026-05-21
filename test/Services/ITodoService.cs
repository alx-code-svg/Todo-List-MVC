using test.DTO;

namespace test.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAllTodosAsync();
        Task<TodoItemDto> CreateTodoAsync(CreateTodoDto dto);
        Task<bool> UpdateTodoAsync(int id, UpdateTodoDto dto);
        Task<bool> DeleteTodoAsync(int id);
    }
}
