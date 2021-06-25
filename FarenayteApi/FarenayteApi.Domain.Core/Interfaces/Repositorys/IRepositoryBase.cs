using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(int id);

        Task UpdateAsync(TEntity obj);

        Task RemoveAsync(TEntity obj);

        void Dispose();
    }
}
