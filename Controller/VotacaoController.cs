using Microsoft.AspNetCore.Mvc;
using VotacaoAPI.DTO;
using VotacaoAPI.exceptions;
using VotacaoAPI.interfaces;
using VotacaoAPI.Services;

namespace VotacaoAPI.Controllers
{
    [ApiController]
    [Route("votacao/[controller]")]
    public class VotacaoController : ControllerBase
    {

        private readonly IVotacaoService _votacaoService;

        public VotacaoController(IVotacaoService votacaoService)
        {
            _votacaoService = votacaoService;
        }


        [HttpPost]
        public async Task<IActionResult> ContabilizarVotos(VotoRequest votoRequest)
        {

            try
            {
                await _votacaoService.RegistrarVotos(votoRequest);
                return Ok("Voto contabilizado!");
            }
            catch (NaoEncontradoException e)
            {
                return BadRequest(e.GetBaseException().Message);
            }
        }

    }    
}