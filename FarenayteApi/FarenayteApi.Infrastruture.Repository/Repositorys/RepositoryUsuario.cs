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

        public virtual async Task<ICollection<Usuario>> GetByEmail(string email) => 
            await _context.Usuarios.Where(x => x.Email == email).ToListAsync();        
                
        public virtual async Task<ICollection<Usuario>> GetAll()
        {
            return await _context.Usuarios.Include(x => x.PessoaFisica).ToListAsync();
        }   

        public virtual void Update(Usuario obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
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
    }
}
