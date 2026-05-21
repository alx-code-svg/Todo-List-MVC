using test.Endpoints;

namespace test.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _todos = new();

        public Task<IEnumerable<TodoItem>> GetAllAsync() => Task.FromResult<IEnumerable<TodoItem>>(_todos);

        public Task<TodoItem?> GetByIdAsync(int id) => Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));

        public Task AddAsync(TodoItem item)
        {
            item.Id = _todos.Count + 1;
            _todos.Add(item);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TodoItem item)
        {
            var existing = _todos.FirstOrDefault(t => t.Id == item.Id);
            if (existing != null)
            {
                existing.Title = item.Title;
                existing.IsCompleted = item.IsCompleted;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _todos.RemoveAll(t => t.Id == id);
            return Task.CompletedTask;
        }
    }
}
