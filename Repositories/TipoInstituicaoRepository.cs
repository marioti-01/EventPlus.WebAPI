using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Models;

using EventPlusWebAPI.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace EventPlusWebAPI.Repositories
{
    public class TipoInstituicaoRepository : IInstituicao
    {
        private readonly EventContext _tipoInstituicao;

        public TipoInstituicaoRepository(EventContext context)
        {
            _tipoInstituicao = context;
        }

        public async Task<List<Instituicao>> Listar()
        {
            return await _tipoInstituicao.Instituicao.ToListAsync();
        }

        public async Task Cadastrar(Instituicao instituicao)
        {
            await _tipoInstituicao.Instituicao.AddAsync(instituicao);
            await _tipoInstituicao.SaveChangesAsync();
        }

        public async Task<Instituicao?> BuscarPorId(Guid id)
        {
            return await _tipoInstituicao.Instituicao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdInstituicao == id);
        }

        public async Task Atualizar(Guid id, Instituicao instituicao)
        {
            var instituicaoBanco = await _tipoInstituicao.Instituicao
                .FirstOrDefaultAsync(i => i.IdInstituicao == id);

            if (instituicaoBanco == null)
            {
                throw new Exception("Instituição não encontrada.");
            }

            instituicaoBanco.Cnpj = instituicao.Cnpj;
            instituicaoBanco.NomeFantasia = instituicao.NomeFantasia;
            instituicaoBanco.Endereco = instituicao.Endereco;

            await _tipoInstituicao.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var tipoInstituicao = await _tipoInstituicao.Instituicao
                .FirstOrDefaultAsync(x => x.IdInstituicao == id);

            if (tipoInstituicao == null)
            {
                throw new Exception("Instituição não encontrada.");
            }

            _tipoInstituicao.Instituicao.Remove(tipoInstituicao);
            await _tipoInstituicao.SaveChangesAsync();
        }

        public Task Cadastrar(TipoInstituicaoDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}