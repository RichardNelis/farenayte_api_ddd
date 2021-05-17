using FarenayteApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FarenayteApi.Infrastructure.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<PublicacaoFoto> PublicacaoFotos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").IsModified = true;
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").IsModified = true;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}