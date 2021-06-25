using FarenayteApi.Domain.Models;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPessoaJuridica : IRepositoryBase<PessoaJuridica>
    {
        Task<PessoaJuridica> GetByIdFullAsync(int id);
    }
}