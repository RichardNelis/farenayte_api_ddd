using FarenayteApi.Domain.Models;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServicePessoaJuridica : IServiceBase<PessoaJuridica>
    {
        Task<PessoaJuridica> GetByIdFullAsync(int id);
    }
}
