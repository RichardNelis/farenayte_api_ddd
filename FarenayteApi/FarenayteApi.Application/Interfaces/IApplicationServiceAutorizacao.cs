﻿using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        Task<LoginResponseDTO> ValidarAcesso(LoginDTO dto);

        Task<LoginResponseDTO> GetById(int id);

        void Dispose();
    }
}
