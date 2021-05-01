using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPesquisa : IMapperPesquisa
    {
        #region Properties

        readonly MapperPublicacao _mapperPublicacao = new MapperPublicacao();

        readonly List<PesquisaResponseDTO> _pessoaJuridicaDTOs = new List<PesquisaResponseDTO>();

        #endregion

        #region methods

        public PessoaJuridica MapperToEntity(PesquisaRequestDTO dto)
        {
            PessoaJuridica obj = new PessoaJuridica
            {
                IBGE = dto.IBGE,
                Publicacao = new Publicacao()
            };

            return obj;
        }

        public ICollection<PesquisaResponseDTO> MapperList(ICollection<PessoaJuridica> objs)
        {
            foreach (var obj in objs)
            {
                PesquisaResponseDTO dto = new PesquisaResponseDTO
                {
                    EsUsuario = obj.EsPessoaFisica,
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

        public PesquisaResponseDTO MapperToDTO(PessoaJuridica obj)
        {
            if (obj == null)
            {
                return null;
            }

            PesquisaResponseDTO dto = new PesquisaResponseDTO
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
