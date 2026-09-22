using Microsoft.EntityFrameworkCore;
using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class CategoryStore
{
    private readonly AppDbContext _context;

    public CategoryStore(AppDbContext context)
    {
        _context = context;
    }

    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Category? GetById(int id)
    {
        return _context.Categories.FirstOrDefault(category => category.Id == id);
    }

    public Category Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return category;
    }
}