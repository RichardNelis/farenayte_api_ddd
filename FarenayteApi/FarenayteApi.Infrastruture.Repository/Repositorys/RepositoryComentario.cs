using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryComentario : RepositoryBase<Comentario>, IRepositoryComentario
    {
        private readonly MySqlContext _context;

        public RepositoryComentario(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }
    }
}
