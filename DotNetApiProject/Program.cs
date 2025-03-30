using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetApiProject.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<DotNetApiProject.Services.UserService>();
builder.Services.AddLogging();

var app = builder.Build();
app.UseMiddleware<LoggingMiddleware>();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
