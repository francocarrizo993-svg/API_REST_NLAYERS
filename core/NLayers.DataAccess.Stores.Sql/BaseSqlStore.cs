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

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        DbSet.Remove(entity);
        await Context.SaveChangesAsync();

        return true;
    }
}