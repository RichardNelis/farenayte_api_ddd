using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPessoaJuridica : RepositoryBase<PessoaJuridica>, IRepositoryPessoaJuridica
    {
        private readonly MySqlContext _context;

        public RepositoryPessoaJuridica(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }       

        public override PessoaJuridica GetById(int id)
        {
            return _context.PessoaJuridicas
                .Where(x => x.EsPessoaFisica == id)
                .Include(x => x.Publicacao)
                .Include(x => x.Publicacao.PublicacaoFotos)
                .FirstOrDefault();
        }      
    }
}
