using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _tipoEvento;
        public TipoEventoController(ITipoEvento tipoEvento)
        {
            _tipoEvento = tipoEvento;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var tipoEventoBuscado = await _tipoEvento.BuscarPorId(id);

            if (tipoEventoBuscado == null)
            {
                return NotFound("Tipo de usuário não encontrado. ");
            }
            return Ok(tipoEventoBuscado);
        }


        /// <summary>
        /// Lista todos os perfis de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var tipos = await _tipoUsuario.Listar();
                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo perfil de usuario
        /// </summary>
        /// <param name="tipoUsuario">perfil de usuario a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] TipoUsuarioDTO dto)
        {
            var tipoUsuario = new TipoUsuario
            {
                IdTipoUsuario = Guid.NewGuid(),
                Titulo = dto.Titulo
            };

            await _tipoUsuario.Cadastrar(tipoUsuario);

            return StatusCode(201, tipoUsuario);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TipoUsuarioDTO dto)
        {
            var tipoUsuarioBuscado = new TipoUsuario
            {
                Titulo = dto.Titulo
            };

            tipoUsuarioBuscado.Titulo = dto.Titulo;
            await _tipoUsuario.Atualizar(id, tipoUsuarioBuscado);
            return Ok(tipoUsuarioBuscado);
        }
        /// <summary>
        /// Cadastra um novo perfil de usuário
        /// Lista todos os perfis de usuário
        /// </summary>
        /// <param name="id">Id do perfil a ser removido</param>
        /// <returns></returns>
        /// 

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _tipoUsuario.Deletar(id);
            return NoContent();
        }
    }
}

''