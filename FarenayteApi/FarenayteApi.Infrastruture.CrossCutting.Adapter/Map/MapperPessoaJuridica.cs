using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPessoaJuridica : IMapperPessoaJuridica
    {
        #region Properties

        readonly MapperPublicacao _mapperPublicacao = new MapperPublicacao();
        readonly List<PessoaJuridicaDTO> _pessoaJuridicaDTOs = new List<PessoaJuridicaDTO>();

        #endregion

        #region methods

        public PessoaJuridica MapperToEntity(PessoaJuridicaDTO dto)
        {
            PessoaJuridica obj = new PessoaJuridica
            {                
                EsPessoaFisica = dto.EsPessoaFisica,
                Logo = dto.Logo,
                Cnpj = dto.Cnpj,
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                TelefoneCelular = dto.TelefoneCelular,
                Whatsapp = dto.Whatsapp,
                EmailContato = dto.EmailContato,
                Rua = dto.Rua,
                Numero = dto.Numero,
                Bairro = dto.Bairro,
                Cep = dto.Cep,
                Complemento = dto.Complemento,
                UF = dto.UF,
                IBGE = dto.IBGE,
                Publicacao = _mapperPublicacao.MapperToEntity(dto.Publicacao)
            };

            return obj;
        }

        public ICollection<PessoaJuridicaDTO> MapperList(ICollection<PessoaJuridica> objs)
        {
            foreach (var obj in objs)
            {
                PessoaJuridicaDTO dto = new PessoaJuridicaDTO
                {                    
                    EsPessoaFisica = obj.EsPessoaFisica,
                    Logo = obj.Logo,
                    Cnpj = obj.Cnpj,
                    RazaoSocial = obj.RazaoSocial,
                    NomeFantasia = obj.NomeFantasia,
                    TelefoneCelular = obj.TelefoneCelular,
                    Whatsapp = obj.Whatsapp,
                    EmailContato = obj.EmailContato,
                    Rua = obj.Rua,
                    Numero = obj.Numero,
                    Bairro = obj.Bairro,
                    Cep = obj.Cep,
                    Complemento = obj.Complemento,
                    UF = obj.UF,
                    IBGE = obj.IBGE,
                    Publicacao = _mapperPublicacao.MapperToDTO(obj.Publicacao)
                };

                _pessoaJuridicaDTOs.Add(dto);
            }

            return _pessoaJuridicaDTOs;
        }

        public PessoaJuridicaDTO MapperToDTO(PessoaJuridica obj)
        {
            if (obj == null)
            {
                return null;
            }

            PessoaJuridicaDTO dto = new PessoaJuridicaDTO
            {                
                EsPessoaFisica = obj.EsPessoaFisica,
                Logo = obj.Logo,
                Cnpj = obj.Cnpj,
                RazaoSocial = obj.RazaoSocial,
                NomeFantasia = obj.NomeFantasia,
                TelefoneCelular = obj.TelefoneCelular,
                Whatsapp = obj.Whatsapp,
                EmailContato = obj.EmailContato,
                Rua = obj.Rua,
                Numero = obj.Numero,
                Bairro = obj.Bairro,
                Cep = obj.Cep,
                Complemento = obj.Complemento,
                UF = obj.UF,
                IBGE = obj.IBGE,
                Publicacao = _mapperPublicacao.MapperToDTO(obj.Publicacao)
            };

            return dto;
        }

        #endregion
    }
}
