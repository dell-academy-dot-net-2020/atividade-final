using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dell.Academy.Atividade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly ILogger<FuncionariosController> _logger;

        public FuncionariosController(ILogger<FuncionariosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}