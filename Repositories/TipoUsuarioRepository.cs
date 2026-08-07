using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly EventContext _context;
        public TipoUsuarioRepository(EventContext contexto) 
        { 

        }
        public Task Atualizar(Guid id, ITipoUsuario TipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<ITipoUsuario> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoUsuario>> Listar()
        {
            return await _context.TipoUsuario.ToListAsync();
        }
    }
}
