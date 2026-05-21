using test.DTO;
using test.Endpoints;
using test.Repositories;

namespace test.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodosAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(t => new TodoItemDto(t.Id, t.Title, t.IsCompleted));
        }

        public async Task<TodoItemDto> CreateTodoAsync(CreateTodoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Il titolo del Todo non può essere vuoto.");

            var item = new TodoItem { Title = dto.Title, IsCompleted = false };
            await _repository.AddAsync(item);

            return new TodoItemDto(item.Id, item.Title, item.IsCompleted);
        }

        public async Task<bool> UpdateTodoAsync(int id, UpdateTodoDto dto)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return false; // Todo non trovato

            item.Title = dto.Title;
            item.IsCompleted = dto.IsCompleted;

            await _repository.UpdateAsync(item);
            return true;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
