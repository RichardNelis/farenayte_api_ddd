using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPesquisa
    {
        Task<ICollection<PessoaJuridica>> GetFilterAsync(dynamic obj);

        void Dispose();
    }
}
