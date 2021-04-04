using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServicePesquisa
    {
        ICollection<PessoaJuridica> GetFilter(PessoaJuridica obj);

        void Dispose();
    }
}
