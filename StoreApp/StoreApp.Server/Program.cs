using Microsoft.EntityFrameworkCore;
using StoreApp.Server.Data;
using StoreApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Чтение строки подключения
var connectionString = builder.Configuration.GetConnectionString("MySQL");

// Регистрация DbContext с использованием MySQL-провайдера
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 40))
    ));


// Добавляем CORS, контроллеры и Swagger
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AnalyticsService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
