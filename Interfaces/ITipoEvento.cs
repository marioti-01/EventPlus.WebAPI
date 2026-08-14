using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Models;

namespace EventPlusWebAPI.Interfaces

/// <summary>
/// Interface do repositório para a entidade TipoEvento
/// Contrato da de TipoEvento, Métodos que deverão ser implementados dentro do repositorio
/// </summary>

{
    public interface ITipoEvento
    {
        Task Cadastrar(TipoEvento tipoEvento);
        Task<List<TipoEvento>> Listar();
        Task<TipoEvento?> BuscarPorId(Guid id);
        Task Atualizar(Guid id, TipoEvento tipoEvento);
        Task Deletar(Guid id);
        Task Cadastrar(TipoEventoDTO dto);
    }
}