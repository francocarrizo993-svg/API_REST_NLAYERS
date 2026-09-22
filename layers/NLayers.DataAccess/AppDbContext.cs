using Microsoft.EntityFrameworkCore;
using NLayers.Entities.Models;

namespace NLayers.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }
}