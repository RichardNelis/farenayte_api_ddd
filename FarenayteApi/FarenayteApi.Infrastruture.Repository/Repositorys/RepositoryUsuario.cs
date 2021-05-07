using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryUsuario : IRepositoryUsuario, IDisposable
    {
        private readonly MySqlContext _context;

        public RepositoryUsuario(MySqlContext Context)
        {
            _context = Context;
        }

        public virtual void Add(Usuario obj)
        {
            try
            {
                _context.Usuarios.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual ICollection<Usuario> GetByEmail(string email) => _context.Usuarios.Where(x => x.Email == email).ToList();

        public virtual Usuario GetById(int id) => _context.Usuarios.Include(x => x.PessoaFisica).FirstOrDefault(x => x.Id == id);

        public virtual void Update(Usuario obj)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Include(x => x.PessoaFisica).First(x => x.Id == obj.Id);
                usuario.PessoaFisica.NomeCompleto = obj.PessoaFisica.NomeCompleto;
                usuario.PessoaFisica.Foto = obj.PessoaFisica.Foto;
                usuario.PessoaFisica.Sexo = obj.PessoaFisica.Sexo;
                usuario.PessoaFisica.TelefoneCelular = obj.PessoaFisica.TelefoneCelular;
                usuario.PessoaFisica.DtNascimento = obj.PessoaFisica.DtNascimento;

                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public ICollection<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
