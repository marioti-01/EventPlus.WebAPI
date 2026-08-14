using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Models;
using EventPlusWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicao;

        public TipoInstituicaoController(IInstituicao instituicao)
        {
            _instituicao = instituicao;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var tipos = await _instituicao.Listar();

                return Ok(tipos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TipoInstituicaoDTO dto)
        {
            try
            {
                var Instituicao = new Instituicao { Cnpj = dto.Cnpj, NomeFantasia = dto.NomeFantasia, Endereco = dto.Endereco }; await _instituicao.Cadastrar(Instituicao);

                return StatusCode(
                    201,
                    "Instituição cadastrada com sucesso " + Instituicao.NomeFantasia

                );
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                var instituicaoBuscada = await _instituicao.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return NotFound("Instituição não encontrada.");
                }

                return Ok(instituicaoBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _instituicao.Deletar(id);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Instituicao instituicao)
        {
            try
            {
                await _instituicao.Atualizar(id, instituicao);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}