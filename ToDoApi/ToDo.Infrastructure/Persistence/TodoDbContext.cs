using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain;

namespace ToDo.Infrastructure.Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
