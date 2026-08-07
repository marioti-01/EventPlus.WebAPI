using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface ITipoUsuario
    {
        Task Cadastrar(TipoUsuario tipoUsuario);

        Task<List<TipoUsuario>> Listar();

        Task Atualizar(Guid id, ITipoUsuario TipoUsuario);

        Task Deletar(Guid id);

        Task<ITipoUsuario> BuscarPorId(Guid id);
    }
}
