using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(int id);

        Task UpdateAsync(TEntity obj);

        Task RemoveAsync(TEntity obj);

        void Dispose();
    }
}
