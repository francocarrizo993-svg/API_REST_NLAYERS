using NLayers.DataAccess.Interfaces;
using NLayers.DataAccess.Stores.Sql;
using NLayers.Entities.Models;

namespace NLayers.DataAccess.Stores;

public class ProductStore : BaseSqlStore<Product>, IProductStore
{
    public ProductStore(AppDbContext context)
        : base(context)
    {
    }
}