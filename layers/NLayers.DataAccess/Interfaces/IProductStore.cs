using NLayers.Entities.Models;

namespace NLayers.DataAccess.Interfaces;

public interface IProductStore
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> AddAsync(Product product);

    Task<Product> UpdateAsync(Product product);

    Task<bool> DeleteAsync(int id);
}