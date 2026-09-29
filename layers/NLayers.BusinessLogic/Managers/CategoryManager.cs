using NLayers.BusinessLogic.Interfaces;
using NLayers.DataAccess.Interfaces;
using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Managers;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryStore _categoryStore;

    public CategoryManager(ICategoryStore categoryStore)
    {
        _categoryStore = categoryStore;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _categoryStore.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _categoryStore.GetByIdAsync(id);
    }

    public async Task<Category> AddAsync(Category category)
    {
        ValidateCategory(category);

        category.Name = category.Name.Trim();
        category.Description = category.Description?.Trim();

        return await _categoryStore.AddAsync(category);
    }

    public async Task<Category?> UpdateAsync(
        int id,
        string name,
        string? description
    )
    {
        var category = await _categoryStore.GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }

        category.Name = name;
        category.Description = description;

        ValidateCategory(category);

        category.Name = category.Name.Trim();
        category.Description = category.Description?.Trim();

        return await _categoryStore.UpdateAsync(category);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _categoryStore.DeleteAsync(id);
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