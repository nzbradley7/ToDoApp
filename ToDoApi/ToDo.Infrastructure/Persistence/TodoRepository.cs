using ToDo.Application.Common.Persistence;
using ToDo.Domain;

namespace ToDo.Infrastructure.Persistence
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TodoItem item)
        {
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public void Edit(TodoItem item)
        {
            _dbContext.TodoItems.Update(item);
            _dbContext.SaveChanges();
        }

        public List<TodoItem> GetAllItems()
        {
            return _dbContext.TodoItems.ToList();
        }

        public TodoItem? GetItemById(Guid id)
        {
            return _dbContext.TodoItems.Find(id);
        }
    }
}
