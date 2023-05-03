using NLog;
using NLog.Web;
using WebApplicationTestExceptions.Db;
using WebApplicationTestExceptions.Exceptions;
using WebApplicationTestExceptions.Repositories;
using WebApplicationTestExceptions.Services;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ToysService>();

builder.Services.AddSingleton<ToysSharpDbContext>();
builder.Services.AddSingleton<IToysRepository, DbToysRepository>();
builder.Services.AddSingleton<IToysService, ToysService>();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();