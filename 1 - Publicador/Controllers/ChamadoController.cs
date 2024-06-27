using _1___Publicador.ApplicationService;
using _1___Publicador.Model;
using Microsoft.AspNetCore.Mvc;

namespace _1___Publicador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChamadoController : Controller
    {
        readonly IApplicationServiceChamado _applicationServiceChamado;
        public ChamadoController(IApplicationServiceChamado applicationServiceChamado)
        {
            _applicationServiceChamado = applicationServiceChamado;
        }

        [HttpPost("Criar-Chamado")]
        public async Task<ActionResult> CriarChamado([FromForm] Chamado chamado)
        {
            if (chamado is null)
                return BadRequest("As informações do chamado não foram fornecidas.");

            var chamadoCriado = await _applicationServiceChamado.CriarChamado(chamado);
            return Ok(chamadoCriado);
        }
    }
}
