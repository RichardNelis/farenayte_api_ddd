using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPesquisa
    {
        ICollection<PessoaJuridica> GetFilter(PessoaJuridica obj);

        void Dispose();
    }
}
