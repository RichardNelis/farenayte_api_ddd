using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePublicacao
    {
        void Add(PublicacaoDTO dto);

        PublicacaoDTO GetById(int id);

        ICollection<PublicacaoDTO> GetAll();

        void Update(PublicacaoDTO dto);

        void Remove(PublicacaoDTO dto);

        void Dispose();
    }
}