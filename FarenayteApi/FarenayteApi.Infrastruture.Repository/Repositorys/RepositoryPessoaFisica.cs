using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPessoaFisica : RepositoryBase<PessoaFisica>, IRepositoryPessoaFisica
    {
        private readonly MySqlContext _context;

        public RepositoryPessoaFisica(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public override PessoaFisica GetById(int id)
        {
            return _context.PessoaFisicas
                .Where(x => x.EsUsuario == id)
                .Include(x => x.PessoaJuridica)
                .FirstOrDefault();
        }
    }
}
