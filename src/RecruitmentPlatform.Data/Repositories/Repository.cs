using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.DbContexts;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    AppDbContext dbContext;
    DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await dbSet.Where(e => e.Id == id && !e.IsDeleted).FirstOrDefaultAsync();
        result.IsDeleted = true;
        await dbContext.SaveChangesAsync();
        return true;
    }

    public IQueryable<TEntity> SelectAll()
    {
        return this.dbSet;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var result = await this.dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
        return result;
    }


    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var result = (dbContext.Update(entity)).Entity;
        await dbContext.SaveChangesAsync();
        return result;
    }
}