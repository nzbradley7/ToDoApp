using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Common.Persistence;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddDbContext<TodoDbContext>(options => options.UseSqlite("Data Source=ToDo.db"));
            return services;
        }
    }
}
