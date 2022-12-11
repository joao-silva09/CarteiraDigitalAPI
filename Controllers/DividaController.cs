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

        /// <summary>
        /// Buscar todas as dívidas do usuário.
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> GetAll()
        {
            return Ok(await _dividaService.GetAllDividas());
        }

        /// <summary>
        /// Buscar uma dívida por id.
        /// </summary>
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

        /// <summary>
        /// Buscar todas as dívidas a pagar.
        /// </summary>
        [HttpGet("Get/APagar")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> GetDividasAPagar()
        {
            return Ok(await _dividaService.GetDividasAPagar());
        }

        /// <summary>
        /// Buscar todas as dívidas a receber.
        /// </summary>
        [HttpGet("Get/AReceber")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> GetDividasAReceber()
        {
            return Ok(await _dividaService.GetDividasAReceber());
        }
        
        /// <summary>
        /// Buscar todas as dívidas pagas.
        /// </summary>
        [HttpGet("Get/pagas")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> GetDividasPagas()
        {
            return Ok(await _dividaService.GetDividasPagas());
        }

        /// <summary>
        /// Adicionar uma nova dívida.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> Add(AddDividaDto newDivida)
        {
            return Ok(await _dividaService.AddDivida(newDivida));
        }

        /// <summary>
        /// Atualizar as informações de uma dívida.
        /// </summary>
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

        /// <summary>
        /// Excluir uma dívida.
        /// </summary>
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

        /// <summary>
        /// Pagar uma dívida.
        /// </summary>
        [HttpPost("Pagar/{dividaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetDividaDto>>>> PagarDivida(int dividaId, PagarDividaDto pagarDividaDto)
        {
            var response = await _dividaService.PagarDivida(dividaId, pagarDividaDto);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
