namespace BlazorAppServer;
public interface IRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task Insert(TEntity entity);

    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task<TEntity?> GetByName(string name);

    Task Update(TEntity entity);

    Task Delete(TEntity student);
    Task Delete(Guid id);
}
