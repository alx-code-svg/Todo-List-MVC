namespace test.DTO
{
    public record TodoItemDto(int Id, string Title, bool IsCompleted);
    public record CreateTodoDto(string Title);
    public record UpdateTodoDto(string Title, bool IsCompleted);
}
