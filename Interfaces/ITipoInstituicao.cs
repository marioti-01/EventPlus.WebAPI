using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Models;

namespace EventPlusWebAPI.Interfaces

/// <summary>
/// Interface do repositório para a entidade TipoInstituicao
/// Contrato da de TipoInstituicao, Métodos que deverão ser implementados dentro do repositorio
/// </summary>

{
    public interface IInstituicao
    {
        Task Cadastrar(Instituicao instituicao);
        Task<List<Instituicao>> Listar();
        Task<Instituicao?> BuscarPorId(Guid id);
        Task Atualizar(Guid id, Instituicao Instituicao);
        Task Deletar(Guid id);
        
    }
}