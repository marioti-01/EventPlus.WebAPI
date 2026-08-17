using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EventContext _context;

        public UsuarioRepository(EventContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Guid id, Usuario usuario)
        {
            var usuarioBuscado = await _context.Usuario.FindAsync(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> BuscarPorEmailESenha(string email, string senha)
        {
            var usuario = await _context.Usuario
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return null;
            }

            bool senhaValida = Criptografia.CompararHash(senha, usuario.Senha);

            if (!senhaValida)
            {
                return null;
            }

            return usuario;
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task Cadastrar(Usuario dto)
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

        public async Task Deletar(Guid id)
        {
            var usuarioBuscado = await _context.Usuario.FindAsync(id);

            if (usuarioBuscado != null)
            {
                _context.Usuario.Remove(usuarioBuscado);
                await _context.SaveChangesAsync();
            }
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