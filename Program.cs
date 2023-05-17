using Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

if (builder.Environment.IsProduction())
{
    // Загружаем строку подключения из окружения
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
        // Если ее нет в окружении, загружаем файл конфигурации
        ?? builder.Configuration.GetConnectionString("PostgresqlConnection")
        // Если строка не найдена, выбрасываем исключение
        ?? throw new InvalidOperationException("Connection string 'PostgresqlConnection' not found.");

    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(connectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseInMemoryDatabase("InMemory"));
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services, app.Environment.IsProduction());
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
