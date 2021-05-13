﻿using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPessoaJuridica : IRepositoryBase<PessoaJuridica>
    {
        Task<PessoaJuridica> GetByIdFullAsync(int id);
    }
}