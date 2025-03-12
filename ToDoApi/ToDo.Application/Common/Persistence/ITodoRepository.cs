using ToDo.Domain;

namespace ToDo.Application.Common.Persistence
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);

        void Edit(TodoItem item);

        TodoItem? GetItemById(Guid id);

        List<TodoItem> GetAllItems();
    }
}
