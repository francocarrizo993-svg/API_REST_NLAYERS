using NLayers.Entities.Models;

namespace NLayers.DataAccess.Interfaces;

public interface ICategoryStore
{
    List<Category> GetAll();

    Category? GetById(int id);

    Category Add(Category category);

    Category Update(Category category);

    bool Delete(int id);
}