namespace RecruitmentPlatform.Data.IRepositories;

public interface  IRepository<TEntity>
{
    IQueryable<TEntity> SelectAll();
    Task<bool> DeleteAsync (long id);
    Task<TEntity> SelectByIdAsync(long id);
    Task<TEntity> InsertAsync (TEntity entity);
    Task<TEntity> UpdateAsync (TEntity entity);
}
