namespace ToDo.Contracts
{
    public record TodoResponse(Guid Id, string Name, DateTime Created, bool IsCompleted);
}
