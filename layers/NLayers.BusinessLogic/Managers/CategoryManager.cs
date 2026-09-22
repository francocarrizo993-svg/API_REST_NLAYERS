using NLayers.DataAccess.Stores;
using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Managers;

public class CategoryManager
{
    private readonly CategoryStore _categoryStore;

    public CategoryManager(CategoryStore categoryStore)
    {
        _categoryStore = categoryStore;
    }

    public List<Category> GetAll()
    {
        return _categoryStore.GetAll();
    }

    public Category? GetById(int id)
    {
        return _categoryStore.GetById(id);
    }

    public Category Add(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException(
                "El nombre de la categoría es obligatorio."
            );
        }

        return _categoryStore.Add(category);
    }
}