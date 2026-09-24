using NLayers.Entities.Models;

namespace NLayers.DataAccess.Interfaces;

public interface IProductStore
{
    List<Product> GetAll();

    Product? GetById(int id);

    Product Add(Product product);

    Product Update(Product product);

    bool Delete(int id);
}