using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;

        public ServiceUsuario(IRepositoryUsuario Repository)
        {
            _repository = Repository;
        }

        public virtual void Add(Usuario obj)
        {
            _repository.Add(obj);
        }

        public virtual ICollection<Usuario> GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        /*public virtual async Task<ICollection<Usuario>> GetAllAsync()
        {
            return await _repository.GetAll();
        }*/

        public virtual void Update(Usuario obj)
        {
            _repository.Update(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }

        public virtual Usuario GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
