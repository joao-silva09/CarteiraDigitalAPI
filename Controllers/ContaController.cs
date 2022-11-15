using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Services.ContaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        /// <summary>
        /// Buscar todas as contas do usuário.
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> GetAll()
        {
            return Ok(await _contaService.GetAllContas());
        }

        /// <summary>
        /// Buscar uma conta por id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetContaDto>>> GetById(int id)
        {
            return Ok(await _contaService.GetContaById(id));
        }

        /// <summary>
        /// Adicionar uma nova conta.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> Add(AddContaDto newConta)
        {
            return Ok(await _contaService.AddConta(newConta));
        }

        /// <summary>
        /// Atualizar as informações de uma conta.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetContaDto>>> Update(UpdateContaDto updatedConta)
        {
            var response = await _contaService.UpdateConta(updatedConta);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Excluir uma conta.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetContaDto>>>> Delete(int id)
        {
            var response = await _contaService.DeleteConta(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
