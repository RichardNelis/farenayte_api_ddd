using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPessoaFisica : IMapperPessoaFisica
    {
        #region Properties

        readonly List<PessoaFisicaDTO> _pessoaFisicaDTOs = new List<PessoaFisicaDTO>();

        #endregion

        #region methods

        public PessoaFisica MapperToEntity(PessoaFisicaDTO dto)
        {
            PessoaFisica obj = new PessoaFisica
            {                
                EsUsuario = dto.EsUsuario,
                Photo = dto.Photo,
                NomeCompleto = dto.NomeCompleto,
                DtNascimento = dto.DtNascimento,
                Sexo = dto.Sexo,
                TelefoneCelular = dto.TelefoneCelular,                
            };

            return obj;
        }

        public ICollection<PessoaFisicaDTO> MapperList(ICollection<PessoaFisica> objs)
        {
            foreach (var obj in objs)
            {
                PessoaFisicaDTO pessoaFisicaDTO = new PessoaFisicaDTO
                {                    
                    EsUsuario = obj.EsUsuario,
                    Photo = obj.Photo,
                    NomeCompleto = obj.NomeCompleto,
                    DtNascimento = obj.DtNascimento,
                    Sexo = obj.Sexo,
                    TelefoneCelular = obj.TelefoneCelular,                    
                };

                _pessoaFisicaDTOs.Add(pessoaFisicaDTO);
            }

            return _pessoaFisicaDTOs;
        }

        public PessoaFisicaDTO MapperToDTO(PessoaFisica obj)
        {
            PessoaFisicaDTO dto = new PessoaFisicaDTO
            {                
                EsUsuario = obj.EsUsuario,
                Photo = obj.Photo,
                NomeCompleto = obj.NomeCompleto,
                DtNascimento = obj.DtNascimento,
                Sexo = obj.Sexo,
                TelefoneCelular = obj.TelefoneCelular,                
            };

            return dto;
        }

        #endregion
    }
}
