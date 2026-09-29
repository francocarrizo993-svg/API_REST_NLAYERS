using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Interfaces;

public interface IProductManager
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> AddAsync(Product product);

    Task<Product?> UpdateAsync(
        int id,
        string name,
        string? description,
        decimal price
    );

    Task<bool> DeleteAsync(int id);
}