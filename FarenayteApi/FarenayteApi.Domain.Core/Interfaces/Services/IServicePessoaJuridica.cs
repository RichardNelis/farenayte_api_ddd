using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServicePessoaJuridica : IServiceBase<PessoaJuridica>
    {
        Task<PessoaJuridica> GetByIdFullAsync(int id);
    }
}
