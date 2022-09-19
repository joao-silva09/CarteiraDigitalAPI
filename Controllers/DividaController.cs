using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Services.DividaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DividaController : ControllerBase
    {
        private readonly IDividaService _dividaService;
        public DividaController(IDividaService dividaService)
        {
            _dividaService = dividaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> GetAll()
        {
            return Ok(await _dividaService.GetAllDividas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDividaDto>>> GetById(int id)
        {
            var response = await _dividaService.GetDividaById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> Add(AddDividaDto newDivida)
        {
            return Ok(await _dividaService.AddDivida(newDivida));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetDividaDto>>> Update(UpdateDividaDto updatedDivida)
        {
            var response = await _dividaService.UpdateDivida(updatedDivida);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> Delete(int id)
        {
            var response = await _dividaService.DeleteDivida(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{dividaId}/{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> PagarDividas(int dividaId, int contaId)
        {
            var response = await _dividaService.PagarDivida(dividaId, contaId);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
