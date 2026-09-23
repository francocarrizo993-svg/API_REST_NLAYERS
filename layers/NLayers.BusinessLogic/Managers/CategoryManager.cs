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
        ValidateCategory(category);

        category.Name = category.Name.Trim();
        category.Description = category.Description?.Trim();

        return _categoryStore.Add(category);
    }

    public Category? Update(int id, string name, string? description)
    {
        var category = _categoryStore.GetById(id);

        if (category == null)
        {
            return null;
        }

        category.Name = name.Trim();
        category.Description = description?.Trim();

        ValidateCategory(category);

        return _categoryStore.Update(category);
    }

    public bool Delete(int id)
    {
        return _categoryStore.Delete(id);
    }

    private static void ValidateCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException(
                "El nombre de la categoría es obligatorio."
            );
        }

        if (category.Name.Length > 100)
        {
            throw new ArgumentException(
                "El nombre de la categoría no puede superar los 100 caracteres."
            );
        }
    }
}