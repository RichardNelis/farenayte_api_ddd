using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPesquisa : IMapperPesquisa
    {
        #region Properties

        readonly List<PesquisaDTO> _pessoaJuridicaDTOs = new List<PesquisaDTO>();

        #endregion

        #region methods

        public PessoaJuridica MapperToEntity(PesquisaDTO dto)
        {
            PessoaJuridica obj = new PessoaJuridica
            {
                Logo = dto.Logo,
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                IBGE = dto.IBGE,
                Publicacao = new Publicacao(titulo: dto.Titulo, descricao: dto.Descricao, preco: dto.Preco),
            };

            return obj;
        }

        public ICollection<PesquisaDTO> MapperList(ICollection<PessoaJuridica> objs)
        {
            foreach (var obj in objs)
            {
                PesquisaDTO dto = new PesquisaDTO
                {
                    Logo = obj.Logo,
                    RazaoSocial = obj.RazaoSocial,
                    NomeFantasia = obj.NomeFantasia,
                    Titulo = obj.Publicacao.Titulo,
                    Descricao = obj.Publicacao.Descricao,
                    Preco = obj.Publicacao.Preco,
                    IBGE = obj.IBGE,
                };

                _pessoaJuridicaDTOs.Add(dto);
            }

            return _pessoaJuridicaDTOs;
        }

        public PesquisaDTO MapperToDTO(PessoaJuridica obj)
        {
            if (obj == null)
            {
                return null;
            }

            PesquisaDTO dto = new PesquisaDTO
            {
                Logo = obj.Logo,
                RazaoSocial = obj.RazaoSocial,
                NomeFantasia = obj.NomeFantasia,
                Titulo = obj.Publicacao.Titulo,
                Descricao = obj.Publicacao.Descricao,
                Preco = obj.Publicacao.Preco,
            };

            return dto;
        }

        #endregion
    }
}
