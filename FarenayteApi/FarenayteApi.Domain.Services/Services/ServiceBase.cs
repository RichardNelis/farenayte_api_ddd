using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            await _repository.UpdateAsync(obj);
        }

        public virtual async Task RemoveAsync(TEntity obj)
        {
            await _repository.RemoveAsync(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
