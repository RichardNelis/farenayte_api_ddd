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

        public virtual async Task AddAsync(Usuario obj)
        {
            try
            {
                await _context.Usuarios.AddAsync(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<ICollection<Usuario>> GetByEmailAsync(string email) => await _context.Usuarios.Where(x => x.Email == email).ToListAsync();

        public virtual async Task<Usuario> GetByIdAsync(int id) => await _context.Usuarios.Include(x => x.PessoaFisica).FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task UpdateAsync(Usuario obj)
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
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public virtual async Task UpdateAlterarSenhaAsync(int id, String password)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Include(x => x.PessoaFisica).First(x => x.Id == id);
                usuario.Password = password;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task RemoveAsync(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
