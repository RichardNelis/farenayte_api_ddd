using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServicePesquisa
    {
        Task<ICollection<PessoaJuridica>> GetFilterAsync(PessoaJuridica obj);

        void Dispose();
    }
}
