using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperAutorizacao : IMapperAutorizacao
    {
        #region Properties
        readonly MapperPessoaFisica _mapperPessoaFisica = new MapperPessoaFisica();

        #endregion

        #region methods

        public LoginResponseDTO MapperToDTO(PessoaFisica obj)
        {
            LoginResponseDTO dto = new LoginResponseDTO
            {
                Id = obj.EsUsuario,
                NomeCompleto = obj.NomeCompleto,
                Foto = obj.Foto,
                EsPessoaJuridica = obj.PessoaJuridica != null ? obj.PessoaJuridica.EsPessoaFisica : 0,
                //PessoaFisica =_mapperPessoaFisica.MapperToDTO(obj),
            };

            return dto;
        }

        #endregion
    }
}
