using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPessoaFisica : RepositoryBase<PessoaFisica>, IRepositoryPessoaFisica
    {
        private readonly MySqlContext _context;

        public RepositoryPessoaFisica(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<PessoaFisica> GetByIdAsync(int id)
        {
            return await _context.PessoaFisicas
                .Where(x => x.EsUsuario == id)
                .Include(x => x.PessoaJuridica)
                .FirstOrDefaultAsync();
        }
    }
}
