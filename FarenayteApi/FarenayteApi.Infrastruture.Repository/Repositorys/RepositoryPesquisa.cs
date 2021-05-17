﻿using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public virtual async Task<ICollection<PessoaJuridica>> GetFilterAsync(dynamic obj)
        {           
            double latitude = obj.Latitude;
            double longitude = obj.Longitude;
            ICollection<PessoaJuridica> list = await _context.PessoaJuridicas
                .Include(x => x.Publicacao)                
                .Where(x => (12742 * Math.Asin(Math.Sqrt(Math.Sin(((Math.PI / 180) * (x.Latitude - latitude)) / 2) * Math.Sin(((Math.PI / 180) * (x.Latitude - latitude)) / 2) +
                                    Math.Cos((Math.PI / 180) * latitude) * Math.Cos((Math.PI / 180) * (x.Latitude)) *
                                    Math.Sin(((Math.PI / 180) * (x.Longitude - longitude)) / 2) * Math.Sin(((Math.PI / 180) * (x.Longitude - longitude)) / 2)))) <= 50)
                .ToListAsync();    

            if (!string.IsNullOrEmpty(obj.RazaoSocial))
            {
                list = list.Where(x => x.RazaoSocial.Contains(obj.RazaoSocial)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.NomeFantasia))
            {
                list = list.Where(x => x.NomeFantasia.Contains(obj.NomeFantasia)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.Titulo))
            {
                list = list.Where(x => x.Publicacao.Titulo.Contains(obj.Publicacao.Titulo)).ToList();
            }

            if (!string.IsNullOrEmpty(obj.Descricao))
            {
                list = list.Where(x => x.Publicacao.Descricao.Contains(obj.Publicacao.Descricao)).ToList();
            }

            if (obj.Preco.HasValue)
            {
                list = list.Where(x => x.Publicacao.Preco == obj.Publicacao.Preco).ToList();
            }

            return list;
        }
    }
}
