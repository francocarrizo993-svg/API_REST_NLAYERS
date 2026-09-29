using NLayers.Entities.Models;

namespace NLayers.DataAccess.Interfaces;

public interface ICategoryStore
{
    Task<List<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category> AddAsync(Category category);

    Task<Category> UpdateAsync(Category category);

    Task<bool> DeleteAsync(int id);
}