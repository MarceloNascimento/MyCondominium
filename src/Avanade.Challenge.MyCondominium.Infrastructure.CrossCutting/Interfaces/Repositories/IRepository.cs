namespace Avanade.Challenge.MyCondominium.Infrastructure.CrossCutting.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T?> Get(int id);
        Task<T> Insert(T param);
        Task<T> Update(T param);
        Task<bool> Delete(T param);
    }
}