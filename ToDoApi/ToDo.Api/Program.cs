using ToDo.Application;
using ToDo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
        });
    });
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.UseCors();

    app.Run();
}