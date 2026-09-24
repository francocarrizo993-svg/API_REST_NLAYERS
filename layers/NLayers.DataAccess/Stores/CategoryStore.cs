using NLayers.DataAccess.Interfaces;
using NLayers.DataAccess.Stores.Sql;
using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class CategoryStore : BaseSqlStore<Category>, ICategoryStore
{
    public CategoryStore(AppDbContext context)
        : base(context)
    {
    }
}