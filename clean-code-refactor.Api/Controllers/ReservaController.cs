using clean_code_refactor.Domain.Bases;
using clean_code_refactor.Domain.Services.Reservas;
using clean_code_refactor.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace clean_code_refactor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController(IReservaService service) : ControllerBase
    {
        private readonly IReservaService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _service.Recuperar());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _service.Recuperar(id);

            return result.Success && result.Value != null
                ? Ok(result.Value)
                : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ReservaViewModel dto)
        {
            try
            {
                var result = await _service.Inserir(dto);
                return result.Success
                    ? Ok(result.Value)
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CheckIn/{id}")]
        public async Task<IActionResult> CheckIn([FromRoute] int id)
        {
            try
            {
                _service.RealizarCheckIn(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CheckOut/{id}")]
        public async Task<IActionResult> CheckOut([FromRoute] int id)
        {
            try
            {
                _service.RealizarCheckOut(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Cancelar/{id}")]
        public async Task<IActionResult> Cancelar([FromRoute] int id)
        {
            try
            {
                _service.Cancelar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
