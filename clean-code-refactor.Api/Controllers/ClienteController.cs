using clean_code_refactor.Domain.Services.Clientes;
using clean_code_refactor.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace clean_code_refactor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {
        #region ctor
        private readonly IClienteService _clienteService = clienteService;
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _clienteService.Recuperar());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _clienteService.Recuperar(id);

            return result.Success && result.Value != null
                ? Ok(result.Value)
                : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                var result = await _clienteService.Inserir(clienteViewModel);

                return result.Success
                    ? Ok(result.Value)
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
