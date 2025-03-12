using ToDo.Application.Common.Persistence;
using ToDo.Domain;

namespace ToDo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public TodoResult AddTodo(string name)
        {
            var newItem = new TodoItem
            {
                Name = name
            };
            _todoRepository.Add(newItem);
            return new TodoResult(newItem);
        }

        public TodoResult EditTodo(Guid id, string name)
        {
            var item = _todoRepository.GetItemById(id);
            if (item is null) { throw new Exception("No item with that Id"); }
            item.Name = name;
            _todoRepository.Edit(item);
            return new TodoResult(item);
        }

        public TodoListResult GetTodos()
        {
            var items = _todoRepository.GetAllItems();
            return new TodoListResult(items);
        }

        public TodoResult MarkCompleted(Guid id)
        {
            var item = _todoRepository.GetItemById(id);
            if (item is null) { throw new Exception("No item with that Id"); }
            item.IsCompleted = true;
            _todoRepository.Edit(item);
            return new TodoResult(item);
        }
    }
}
