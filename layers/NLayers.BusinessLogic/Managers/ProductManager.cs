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

    public List<Product> GetAll()
    {
        return _productStore.GetAll();
    }

    public Product? GetById(int id)
    {
        return _productStore.GetById(id);
    }

    public Product Add(Product product)
    {
        ValidateProduct(product);

        product.Name = product.Name.Trim();
        product.Description = product.Description?.Trim();

        return _productStore.Add(product);
    }

    public Product? Update(
        int id,
        string name,
        string? description,
        decimal price
    )
    {
        var product = _productStore.GetById(id);

        if (product == null)
        {
            return null;
        }

        product.Name = name.Trim();
        product.Description = description?.Trim();
        product.Price = price;

        ValidateProduct(product);

        return _productStore.Update(product);
    }

    public bool Delete(int id)
    {
        return _productStore.Delete(id);
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