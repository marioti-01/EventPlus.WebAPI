using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using EventPlusWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.Web.API.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }

        public Task Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> BuscarPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task Cadastrar(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = Criptografia.GerarHash(dto.Senha),  
                IdUsuario = Guid.NewGuid()
            };

            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _context.Usuario
                .Include(u => u.IdTipoUsuarioNavigation)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}