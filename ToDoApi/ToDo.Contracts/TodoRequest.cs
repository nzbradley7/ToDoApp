namespace ToDo.Contracts
{
    public record TodoRequest(
        Guid Id, string Name, bool IsCompleted);
}
