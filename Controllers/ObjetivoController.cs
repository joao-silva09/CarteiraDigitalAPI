using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Objetivo;
using CarteiraDigitalAPI.Services.DividaService;
using CarteiraDigitalAPI.Services.ObjetivoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoService _objetivoService;
        public ObjetivoController(IObjetivoService objetivoService)
        {
            _objetivoService = objetivoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> GetAll()
        {
            return Ok(await _objetivoService.GetAllObjetivos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetObjetivoDto>>> GetById(int id)
        {
            var response = await _objetivoService.GetObjetivoById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> Add(AddObjetivoDto newObjetivo)
        {
            return Ok(await _objetivoService.AddObjetivo(newObjetivo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetObjetivoDto>>> Update(UpdateObjetivoDto updatedObjetivo)
        {
            var response = await _objetivoService.UpdateObjetivo(updatedObjetivo);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> Delete(int id)
        {
            var response = await _objetivoService.DeleteObjetivo(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
