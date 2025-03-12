namespace ToDo.Application.Services
{
    public interface ITodoService
    {
        public TodoResult AddTodo(string name);

        public TodoListResult GetTodos();

        public TodoResult EditTodo(Guid id, string name);

        public TodoResult MarkCompleted(Guid id);
    }
}
