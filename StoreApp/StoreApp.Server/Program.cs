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
    options.UseMySQL(builder.Configuration.GetConnectionString(nameof(StoreApp)), mysqlOptions =>
    {
        mysqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
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
