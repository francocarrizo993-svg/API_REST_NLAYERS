using Microsoft.EntityFrameworkCore;
using NLayers.DataAccess;
using NLayers.DataAccess.Stores;
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
builder.Services.AddScoped<CategoryStore>();
builder.Services.AddScoped<CategoryManager>();

builder.Services.AddScoped<ProductStore>();
builder.Services.AddScoped<ProductManager>();

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