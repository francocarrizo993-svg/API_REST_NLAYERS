using Microsoft.EntityFrameworkCore;
using NLayers.DataAccess;
using NLayers.DataAccess.Interfaces;
using NLayers.DataAccess.Stores;
using NLayers.BusinessLogic.Interfaces;
using NLayers.BusinessLogic.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(NLayers.Presentation.Controllers.CategoryController).Assembly);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext con PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<ICategoryStore, CategoryStore>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();

builder.Services.AddScoped<IProductStore, ProductStore>();
builder.Services.AddScoped<IProductManager, ProductManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();