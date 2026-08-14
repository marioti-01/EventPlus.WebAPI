using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

/// <summary>
/// Data Transfer Object (DTO) para cadastro e atualização do perfil/tipo de usuario
/// </summary>
public class TipoInstituicaoDTO
{
    /// <summary>
    /// Titulo do tipo de instituição
    /// </summary>

    public string Cnpj{ get; set; }
    public string NomeFantasia { get; set; }
    public string Endereco { get; set; }

    public Guid IdInstituicao { get; }
}
