using NLayers.DataAccess.Stores.Sql;
using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class CategoryStore : BaseSqlStore<Category>
{
    public CategoryStore(AppDbContext context) : base(context)
    {
    }
}