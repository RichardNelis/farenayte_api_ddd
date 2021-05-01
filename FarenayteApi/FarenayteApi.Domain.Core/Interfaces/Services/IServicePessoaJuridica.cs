using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServicePessoaJuridica : IServiceBase<PessoaJuridica>
    {
        PessoaJuridica GetByIdFull(int id);
    }
}
