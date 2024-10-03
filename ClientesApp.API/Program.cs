using ClientesApp.API.Extensions;
using ClientesApp.Infra.Data.SqlServer.Extensions;
using ClientesApp.Domain.Extensions;
using ClientesApp.Application.Extensions;
using ClientesApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddEntityFramework(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddDomainService();

var app = builder.Build();

// ------------------------------------------------------------------------------ //

app.UseSwaggerConfig();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseMiddleware<NotFoundExceptionMiddleware>();

app.Run();
