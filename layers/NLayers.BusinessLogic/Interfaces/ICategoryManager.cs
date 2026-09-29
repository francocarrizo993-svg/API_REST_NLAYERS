using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Interfaces;

public interface ICategoryManager
{
    Task<List<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category> AddAsync(Category category);

    Task<Category?> UpdateAsync(
        int id,
        string name,
        string? description
    );

    Task<bool> DeleteAsync(int id);
}