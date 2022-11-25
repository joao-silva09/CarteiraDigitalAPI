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

        /// <summary>
        /// Buscar todos os objetivos.
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> GetAll()
        {
            return Ok(await _objetivoService.GetAllObjetivos());
        }

        /// <summary>
        /// Buscar objetivos a cumprir.
        /// </summary>
        [HttpGet("Get/aCumprir")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> GetACumprir()
        {
            return Ok(await _objetivoService.GetObjetivosACumprir());
        }
        
        /// <summary>
        /// Buscar objetivos cumpridos.
        /// </summary>
        [HttpGet("GetAll/cumpridos")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> GetCumpridos()
        {
            return Ok(await _objetivoService.GetObjetivosCumpridos());
        }

        /// <summary>
        /// Buscar um objetivo por id.
        /// </summary>
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

        /// <summary>
        /// Criar um novo objetivo.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> Add(AddObjetivoDto newObjetivo)
        {
            return Ok(await _objetivoService.AddObjetivo(newObjetivo));
        }

        /// <summary>
        /// Cumprir um objetivo.
        /// </summary>
        [HttpPost("{objetivoId}/{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetObjetivoDto>>>> Cumprir(int objetivoId, int? contaId)
        {
            return Ok(await _objetivoService.CumprirObjetivo(objetivoId, contaId));
        }

        /// <summary>
        /// Atualizar as informações de um objetivo.
        /// </summary>
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

        /// <summary>
        /// Excluir um objetivo.
        /// </summary>
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
