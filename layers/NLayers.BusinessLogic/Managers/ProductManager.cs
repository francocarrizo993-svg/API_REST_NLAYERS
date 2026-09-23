using NLayers.DataAccess.Stores;
using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Managers;

public class ProductManager
{
    private readonly ProductStore _productStore;

    public ProductManager(ProductStore productStore)
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
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException(
                "El nombre del producto es obligatorio."
            );
        }

        return _productStore.Add(product);
    }
}