using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPublicacao : RepositoryBase<Publicacao>, IRepositoryPublicacao
    {
        private readonly MySqlContext _context;

        public RepositoryPublicacao(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }
    }
}
