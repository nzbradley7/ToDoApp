namespace ToDo.Domain
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
    }
}
