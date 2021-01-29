using Dell.Academy.Atividade.Application.Extensions;
using Dell.Academy.Atividade.Application.Interfaces;
using Dell.Academy.Atividade.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Atividade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly ILogger<FuncionariosController> _logger;
        private readonly IFuncionarioService _service;

        public FuncionariosController(ILogger<FuncionariosController> logger, IFuncionarioService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuncionarioViewModel>>> Get()
            => Ok(await _service.GetFuncionariosAsync());

        [Route("cpf/{cpf}")]
        [HttpGet]
        public async Task<ActionResult<FuncionarioViewModel>> Get(string cpf)
        {
            var viewModel = await _service.GetFuncionarioByCpfAsync(cpf);

            if (viewModel is null)
                return NotFound(new
                {
                    Errors = new List<string> {
                    ErrorMessages.FuncionarioCpfExistsError(cpf)
                }
                });

            return Ok(viewModel);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<FuncionarioViewModel>> Get(long id)
        {
            var viewModel = await _service.GetFuncionarioByIdAsync(id);

            if (viewModel is null)
                return NotFound(new
                {
                    Errors = new List<string> {
                    ErrorMessages.FuncionarioIdExistsError(id)
                }
                });

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ErrorViewModel>> Post(FuncionarioViewModel viewModel)
            => CustomResponse(await _service.InsertFuncionarioAsync(viewModel));

        [HttpPut]
        public async Task<ActionResult<ErrorViewModel>> Put(FuncionarioViewModel viewModel)
            => CustomResponse(await _service.UpdateFuncionarioAsync(viewModel));

        [Route("endereco")]
        [HttpPut]
        public async Task<ActionResult<ErrorViewModel>> Put(EnderecoViewModel viewModel)
            => CustomResponse(await _service.UpdateEnderecoAsync(viewModel));

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<ErrorViewModel>> Delete(long id)
            => CustomResponse(await _service.DeleteFuncionarioAsync(id));

        private ActionResult CustomResponse(ErrorViewModel viewModel)
        {
            if (viewModel.HasErrors) return BadRequest(new { Errors = viewModel.Errors });

            return Ok();
        }
    }
}