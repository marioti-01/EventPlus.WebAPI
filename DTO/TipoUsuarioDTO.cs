using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

/// <summary>
/// Data Transfer Object (DTO) para cadastro e atualização do perfil/tipo de usuario
/// </summary>
public class TipoUsuarioDTO
{
    /// <summary>
    /// Titulo do tipo de usuario
    /// </summary>
    [Required(ErrorMessage = "O titulo é obrigatório.")]
    [StringLength(100, ErrorMessage = "O titulo pode ter no maximo 100 caracteres")]
    public string Titulo { get; set; } = string.Empty;
}
