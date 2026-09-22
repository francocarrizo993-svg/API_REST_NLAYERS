using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class CategoryStore
{
    private readonly List<Category> _categories = new();

    public List<Category> GetAll()
    {
        return _categories;
    }

    public Category? GetById(int id)
    {
        return _categories.FirstOrDefault(category => category.Id == id);
    }

    public Category Add(Category category)
    {
        category.Id = _categories.Count + 1;

        _categories.Add(category);

        return category;
    }
}