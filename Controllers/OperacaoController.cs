using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Operacao;
using CarteiraDigitalAPI.Models.Enum;
using CarteiraDigitalAPI.Services.DividaService;
using CarteiraDigitalAPI.Services.OperacaoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperacaoController : ControllerBase
    {
        private readonly IOperacaoService _operacaoService;
        public OperacaoController(IOperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
        }

        /// <summary>
        /// Buscar todas as operações.
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetAll()
        {
            return Ok(await _operacaoService.GetAllOperacoes());
        }
        
        /// <summary>
        /// Buscar todos os gastos.
        /// </summary>
        [HttpGet("Get/gastos")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetGastos()
        {
            return Ok(await _operacaoService.GetAllGastos());
        }
             
        /// <summary>
        /// Buscar todos os gastos de um determinado mês.
        /// </summary>
        [HttpGet("Get/gastos/{month}/{year}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetGastosByMonth(int month, int year)
        {
            return Ok(await _operacaoService.GetGastosByMonth(month, year));
        }
        
        /// <summary>
        /// Buscar todos os recebimentos.
        /// </summary>
        [HttpGet("Get/recebimentos")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetRecebimentos()
        {
            return Ok(await _operacaoService.GetAllRecebimentos());
        }

        /// <summary>
        /// Buscar todos os recebimentos de um determinado mês.
        /// </summary>
        [HttpGet("Get/recebimentos/{month}/{year}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetRecebimentosByMonth(int month, int year)
        {
            return Ok(await _operacaoService.GetRecebimentosByMonth(month, year));
        }

        /// <summary>
        /// Buscar todas as operações de um determinado mês.
        /// </summary>
        [HttpGet("Get/{month}/{year}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetByMonth(int month, int year)
        {
            return Ok(await _operacaoService.GetOperacoesByMonth(month, year));
        }
        
        /// <summary>
        /// Buscar todas as operações de um determinado mês e tipo.
        /// </summary>
        [HttpGet("Get/{month}/{year}/{type}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetByMonthAndType(int month, int year, TipoOperacao? type)
        {
            return Ok(await _operacaoService.GetOperacoesByMonthAndType(month, year, type));
        }

        /// <summary>
        /// Buscar contagem de operações.
        /// </summary>
        [HttpGet("Get/dados/{month}/{year}")]
        public async Task<ActionResult<ServiceResponse<GetDadosDto>>> GetContagem(int month, int year)
        {
            return Ok(await _operacaoService.GetNumeroDeOperacoes(month, year));
        }
        
        /// <summary>
        /// Buscar todas as operações de uma conta.
        /// </summary>
        [HttpGet("conta/{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> GetByConta(int contaId)
        {
            return Ok(await _operacaoService.GetOperacoesByConta(contaId));
        }

        /// <summary>
        /// Buscar uma única operação.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOperacaoDto>>> GetById(int id)
        {
            var response = await _operacaoService.GetOperacaoById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Adicionar uma nova operação de gasto.
        /// </summary>
        [HttpPost("gasto/{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> AddGastos(AddOperacaoDto newOperacao, int contaId)
        {
            return Ok(await _operacaoService.AddGasto(newOperacao, contaId));
        }

        /// <summary>
        /// Atualizar as infomações de uma operação.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetOperacaoDto>>> Update(UpdateOperacaoDto updatedOperacao)
        {
            var response = await _operacaoService.UpdateOperacao(updatedOperacao);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Excluir uma operação.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> Delete(int id)
        {
            var response = await _operacaoService.DeleteOperacao(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Adicionar uma nova operação de receita.
        /// </summary>
        [HttpPost("receita/{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> AddReceita(AddOperacaoDto newOperacao, int contaId)
        {
            return Ok(await _operacaoService.AddReceita(newOperacao, contaId));
        }

        /// <summary>
        /// Adicionar uma nova operação.
        /// </summary>
        [HttpPost("{contaId}")]
        public async Task<ActionResult<ServiceResponse<List<GetOperacaoDto>>>> AddOperacao(AddOperacaoDto newOperacao, int contaId)
        {
            return Ok(await _operacaoService.AddOperacao(newOperacao, contaId));
        }
    }
}
