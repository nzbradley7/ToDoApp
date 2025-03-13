using ToDo.Application;
using ToDo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowLocalOrigins", policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
    });
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers().RequireCors("AllowLocalOrigins");

    app.UseCors();

    app.Run();
}