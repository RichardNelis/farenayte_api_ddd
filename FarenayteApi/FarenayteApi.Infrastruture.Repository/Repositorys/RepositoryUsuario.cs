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
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly MySqlContext _context;

        public RepositoryUsuario(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<Usuario> GetByEmailAsync(string email) => await _context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<Usuario> GetByIdAsync(int id) => await _context.Usuarios.Include(x => x.PessoaFisica).FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Usuario obj)
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

        public async Task UpdateAlterarSenhaAsync(int id, String password)
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
    }
}
