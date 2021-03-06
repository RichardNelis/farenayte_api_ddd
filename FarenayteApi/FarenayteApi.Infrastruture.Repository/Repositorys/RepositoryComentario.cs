using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryComentario : RepositoryBase<Comentario>, IRepositoryComentario
    {
        private readonly MySqlContext _context;

        public RepositoryComentario(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao)
        {
            return await _context.Comentarios.Include(x => x.PessoaFisica).Where(x => x.EsPublicacao == esPublicacao).ToListAsync();
        }

        public async Task<Comentario> GetByIdWithPessoaFisicaAsync(int id) => await _context.Comentarios.Include(x => x.PessoaFisica).Where(x => x.Id == id).FirstAsync();
    }
}
