using NLayers.Entities.Models;

namespace NLayers.BusinessLogic.Interfaces;

public interface ICategoryManager
{
    List<Category> GetAll();

    Category? GetById(int id);

    Category Add(Category category);

    Category? Update(
        int id,
        string name,
        string? description
    );

    bool Delete(int id);
}