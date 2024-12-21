﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server;
using StoreApp.Server.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IStoreAppRepository, StoreAppRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

builder.Services.AddDbContextFactory<StoreAppContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(StoreApp));
    optionsBuilder.UseMySQL(connectionString, options =>
        options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
});

var app = builder.Build();

// Apply migrations at runtime
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreAppContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();