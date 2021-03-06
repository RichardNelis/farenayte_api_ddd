using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPesquisa : RepositoryBase<PessoaJuridica>, IRepositoryPesquisa
    {
        private readonly MySqlContext _context;

        public RepositoryPesquisa(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<ICollection<PessoaJuridica>> GetFilterAsync(dynamic obj)
        {
            double latitude = obj.Latitude;
            double longitude = obj.Longitude;
            double distancia = obj.Distancia;

            ICollection<PessoaJuridica> list = await _context.PessoaJuridicas
                .Include(x => x.Publicacao)
                    .ThenInclude(x => x.Comentarios)
                /*.Where(x => (12742 * Math.Asin(Math.Sqrt(Math.Sin(((Math.PI / 180) * (x.Latitude - latitude)) / 2) * Math.Sin(((Math.PI / 180) * (x.Latitude - latitude)) / 2) +
                                     Math.Cos((Math.PI / 180) * latitude) * Math.Cos((Math.PI / 180) * (x.Latitude)) *
                                     Math.Sin(((Math.PI / 180) * (x.Longitude - longitude)) / 2) * Math.Sin(((Math.PI / 180) * (x.Longitude - longitude)) / 2)))) <= distancia)*/
                .OrderBy(x => x.Publicacao.PessoaJuridica.NomeFantasia)
                    .ThenBy(x => x.Publicacao.Comentarios.ToList().Count)
                    .ThenByDescending(x => x.Publicacao.Comentarios.Average(y => y.Rating))
                .ToListAsync();

            return list;
        }
    }
}
