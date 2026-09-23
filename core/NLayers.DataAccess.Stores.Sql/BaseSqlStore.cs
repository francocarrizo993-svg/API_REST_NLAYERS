using Microsoft.EntityFrameworkCore;

namespace NLayers.DataAccess.Stores.Sql;

public abstract class BaseSqlStore<TEntity> where TEntity : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseSqlStore(DbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual List<TEntity> GetAll()
    {
        return DbSet.ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual TEntity Add(TEntity entity)
    {
        DbSet.Add(entity);
        Context.SaveChanges();

        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        DbSet.Update(entity);
        Context.SaveChanges();

        return entity;
    }

    public virtual bool Delete(int id)
    {
        var entity = DbSet.Find(id);

        if (entity == null)
        {
            return false;
        }

        DbSet.Remove(entity);
        Context.SaveChanges();

        return true;
    }
}