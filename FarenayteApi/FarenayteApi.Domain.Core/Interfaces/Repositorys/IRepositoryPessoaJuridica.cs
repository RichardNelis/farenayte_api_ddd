﻿using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPessoaJuridica : IRepositoryBase<PessoaJuridica>
    {
        PessoaJuridica GetByIdFull(int id);
    }
}