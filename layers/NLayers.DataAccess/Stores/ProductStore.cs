using NLayers.DataAccess.Stores.Sql;
using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class ProductStore : BaseSqlStore<Product>
{
    public ProductStore(AppDbContext context) : base(context)
    {
    }
}