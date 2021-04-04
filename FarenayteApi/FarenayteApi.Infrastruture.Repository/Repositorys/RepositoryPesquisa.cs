using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPesquisa : RepositoryBase<PessoaJuridica>, IRepositoryPesquisa
    {
        private readonly MySqlContext _context;

        public RepositoryPesquisa(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public virtual ICollection<PessoaJuridica> GetFilter(PessoaJuridica obj)
        {
            ICollection<PessoaJuridica> list = _context.PessoaJuridicas
                .Include(x => x.Publicacao).ThenInclude(x => x.Comentarios)
                .Include(x => x.Publicacao).ThenInclude(x => x.PublicacaoFotos)
                .Include(x => x.Publicacao.Comentarios).ThenInclude(x => x.PessoaFisica)
                .Where(x => x.IBGE == obj.IBGE)
                .ToList();

            if (!string.IsNullOrEmpty(obj.RazaoSocial))
            {
                list = list.Where(x => x.RazaoSocial.Contains(obj.RazaoSocial)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.NomeFantasia))
            {
                list = list.Where(x => x.NomeFantasia.Contains(obj.NomeFantasia)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.Publicacao.Titulo))
            {
                list = list.Where(x => x.Publicacao.Titulo.Contains(obj.Publicacao.Titulo)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.Publicacao.Descricao))
            {
                list = list.Where(x => x.Publicacao.Descricao.Contains(obj.Publicacao.Descricao)).ToList();
            }

            if (obj.Publicacao.Preco.HasValue)
            {
                list = list.Where(x => x.Publicacao.Preco == obj.Publicacao.Preco).ToList();
            }

            return list;
        }
    }
}
