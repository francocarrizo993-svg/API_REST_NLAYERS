using NLayers.BusinessLogic.Interfaces;
using NLayers.DataAccess.Interfaces;
using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductStore _productStore;

    public ProductManager(IProductStore productStore)
    {
        _productStore = productStore;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _productStore.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productStore.GetByIdAsync(id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        ValidateProduct(product);

        product.Name = product.Name.Trim();
        product.Description = product.Description?.Trim();

        return await _productStore.AddAsync(product);
    }

    public async Task<Product?> UpdateAsync(
        int id,
        string name,
        string? description,
        decimal price
    )
    {
        var product = await _productStore.GetByIdAsync(id);

        if (product == null)
        {
            return null;
        }

        product.Name = name.Trim();
        product.Description = description?.Trim();
        product.Price = price;

        ValidateProduct(product);

        return await _productStore.UpdateAsync(product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productStore.DeleteAsync(id);
    }

    private static void ValidateProduct(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException(
                "El nombre del producto es obligatorio."
            );
        }

        if (product.Name.Length > 100)
        {
            throw new ArgumentException(
                "El nombre del producto no puede superar los 100 caracteres."
            );
        }
    }
}