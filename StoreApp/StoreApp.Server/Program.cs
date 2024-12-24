using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server;
using StoreApp.Server.Repository;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

// Configure AutoMapper
builder.Services.AddSingleton<IMapper>(new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}).CreateMapper());

// Register services
builder.Services.AddScoped<IStoreAppRepository, StoreAppRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

// Database configuration
builder.Services.AddDbContextFactory<StoreAppContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(StoreApp));
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)), mysqlOptions =>
    {
        mysqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });
});


var app = builder.Build();

// Apply pending migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreAppContext>();
    dbContext.Database.Migrate();
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
