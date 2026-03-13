using Aplication.IServices;
using Aplication.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using System.Net.Mime;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AssinantesController : ControllerBase
    {
        private readonly IAssinanteService _service;

        public AssinantesController(IAssinanteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os assinantes que estão com status Ativo.
        /// </summary>
        /// <response code="200">Retorna a lista de assinantes ativos.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AsssinanteReponserModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ObterTodosAtivos()
        {
            var assinantes = await _service.ObterTodosAtivos();
            return Ok(assinantes);
        }

        /// <summary>
        /// Obtém detalhes de um assinante ativo pelo seu ID.
        /// </summary>
        /// <param name="id">GUID do assinante.</param>
        /// <response code="200">Retorna o assinante solicitado.</response>
        /// <response code="404">Assinante não encontrado ou está inativo.</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(AsssinanteReponserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            var assinante = await _service.ObterPorId(id);
            if (assinante == null)
                return NotFound(new { mensagem = "Assinante não encontrado ou inativo." });

            return Ok(assinante);
        }

        /// <summary>
        /// Cadastra um novo assinante validando e-mail, valor e data.
        /// </summary>
        /// <response code="201">Assinante cadastrado com sucesso.</response>
        /// <response code="400">Falha nas regras de negócio.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Adicionar(AssinanteRequestModel request)
        {
            try
            {
                await _service.Adicionar(request);
                return StatusCode(201, new { mensagem = "Cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza dados de um assinante (Somente se ele estiver ativo).
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] EditarAssinanteModel request)
        {
            try
            {
                await _service.Atualizar(id, request);
                return StatusCode(201, new { mensagem = "Atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Desativa um assinante mudando seu status para Inativo.
        /// </summary>
        [HttpPatch("{id:guid}/desativar")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public async Task<ActionResult> Desativar(Guid id)
        {
            try
            {
                await _service.Desativar(id);
                return Ok(new { mensagem = "Assinante desativado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}