using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Objetivo;
using CarteiraDigitalAPI.Dtos.Planejamento;
using CarteiraDigitalAPI.Services.DividaService;
using CarteiraDigitalAPI.Services.ObjetivoService;
using CarteiraDigitalAPI.Services.PlanejamentoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlanejamentoController : ControllerBase
    {
        private readonly IPlanejamentoService _planejamentoService;
        public PlanejamentoController(IPlanejamentoService planejamentoService)
        {
            _planejamentoService = planejamentoService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPlanejamentoDto>>>> GetAll()
        {
            return Ok(await _planejamentoService.GetAllPlanejamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPlanejamentoDto>>> GetById(int id)
        {
            var response = await _planejamentoService.GetPlanejamentoById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPlanejamentoDto>>>> Add(AddPlanejamentoDto newPlanejamento)
        {
            return Ok(await _planejamentoService.AddPlanejamento(newPlanejamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPlanejamentoDto>>> Update(UpdatePlanejamentoDto updatedPlanejamento)
        {
            var response = await _planejamentoService.UpdatePlanejamento(updatedPlanejamento);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPlanejamentoDto>>>> Delete(int id)
        {
            var response = await _planejamentoService.DeletePlanejamento(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
