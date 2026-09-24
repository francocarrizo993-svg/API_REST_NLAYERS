using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Interfaces;

public interface IProductManager
{
    List<Product> GetAll();

    Product? GetById(int id);

    Product Add(Product product);

    Product? Update(
        int id,
        string name,
        string? description,
        decimal price
    );

    bool Delete(int id);
}