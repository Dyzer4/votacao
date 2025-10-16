using Microsoft.AspNetCore.Mvc;
using VotacaoAPI.Services;
using VotacaoAPI.Model;

namespace VotacaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly CandidatoService _service;

        public CandidatoController(CandidatoService service)
        {
            _service = service;
        }

        [HttpGet("{idCipa}")]
        public async Task<ActionResult<List<CandidatoModel>>> GetAll(int idCipa)
        {
            var candidatos = await _service.ListarTodosCandidatosPorCipa(idCipa);
            
            if (candidatos == null || candidatos.Count == 0)
                return NotFound("Nenhum candidato encontrado para essa CIPA.");
            
            return Ok(candidatos);
        }
        
        [HttpGet("aprovados/{idCipa}")]
        public async Task<ActionResult<List<CandidatoModel>>> GetAprovadosPorCipa(int idCipa)
        {
            var candidatos = await _service.ListarAprovadosPorCipaAsync(idCipa);
    
            if (candidatos == null || candidatos.Count == 0)
                return NotFound("Nenhum candidato aprovado encontrado para essa CIPA.");

            return Ok(candidatos);
        }
    }
}
