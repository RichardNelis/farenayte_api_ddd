using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MySqlContext _context;

        public RepositoryBase(MySqlContext Context)
        {
            _context = Context;
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task RemoveAsync(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                await _context.SaveChangesAsync();
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