using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Interfaces
{
    public interface ITipoUsuario
    {
        Task Cadastrar(TipoUsuario tipoUsuario);

        Task<List<TipoUsuario>> Listar();

        Task Atualizar(Guid id, ITipoUsuario TipoUsuario);

        Task Deletar(Guid id);

        Task<TipoUsuario?> BuscarPorId(Guid id);
        Task Atualizar(Guid id, TipoUsuario tipoUsuarioBuscado);
    }
}
