namespace Avanade.Challenge.MyCondominium.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(int id, CancellationToken cancellationToken);
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken);        
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}