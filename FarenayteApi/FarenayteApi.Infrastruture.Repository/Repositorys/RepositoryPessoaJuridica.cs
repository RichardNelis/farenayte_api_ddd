using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Infrastruture.Repository.Repositorys
{
    public class RepositoryPessoaJuridica : RepositoryBase<PessoaJuridica>, IRepositoryPessoaJuridica
    {
        private readonly MySqlContext _context;

        public RepositoryPessoaJuridica(MySqlContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<PessoaJuridica> GetByIdAsync(int id)
        {
            return await _context.PessoaJuridicas
                .Where(x => x.EsPessoaFisica == id)
                .Include(x => x.Publicacao).ThenInclude(x => x.PublicacaoFotos)
                .FirstOrDefaultAsync();
        }

        public async Task<PessoaJuridica> GetByIdFullAsync(int id)
        {
            return await _context.PessoaJuridicas
                .Where(x => x.EsPessoaFisica == id)
                .Include(x => x.Publicacao).ThenInclude(x => x.PublicacaoFotos)
                .Include(x => x.Publicacao).ThenInclude(x => x.Comentarios).ThenInclude(x => x.PessoaFisica)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(PessoaJuridica obj)
        {
            try
            {
                PessoaJuridica pessoaJuridica = await _context.PessoaJuridicas
                    .Include(x => x.Publicacao)
                    .ThenInclude(x => x.PublicacaoFotos)
                    .FirstAsync(x => x.EsPessoaFisica == obj.EsPessoaFisica);

                pessoaJuridica.Logo = obj.Logo;
                pessoaJuridica.Cnpj = obj.Cnpj;
                pessoaJuridica.RazaoSocial = obj.RazaoSocial;
                pessoaJuridica.NomeFantasia = obj.NomeFantasia;
                pessoaJuridica.TelefoneCelular = obj.TelefoneCelular;
                pessoaJuridica.Whatsapp = obj.Whatsapp;
                pessoaJuridica.EmailContato = obj.EmailContato;
                pessoaJuridica.Site = obj.Site;
                pessoaJuridica.Rua = obj.Rua;
                pessoaJuridica.Numero = obj.Numero;
                pessoaJuridica.Bairro = obj.Bairro;
                pessoaJuridica.Cep = obj.Cep;
                pessoaJuridica.Complemento = obj.Complemento;
                pessoaJuridica.UF = obj.UF;
                pessoaJuridica.IBGE = obj.IBGE;

                pessoaJuridica.Publicacao.Titulo = obj.Publicacao.Titulo;
                pessoaJuridica.Publicacao.Descricao = obj.Publicacao.Descricao;
                pessoaJuridica.Publicacao.Preco = obj.Publicacao.Preco;
                pessoaJuridica.Publicacao.TipoCobranca = obj.Publicacao.TipoCobranca;

                pessoaJuridica.Publicacao.PublicacaoFotos = obj.Publicacao.PublicacaoFotos;

                _context.Entry(pessoaJuridica).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
