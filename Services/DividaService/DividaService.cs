using AutoMapper;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Operacao;
using CarteiraDigitalAPI.Models;
using CarteiraDigitalAPI.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Services.DividaService
{
    public class DividaService : IDividaService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DividaService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetDividaDto>>> AddDivida(AddDividaDto newDivida)
        {
            var serviceResponse = new ServiceResponse<List<GetDividaDto>>();
            Divida divida = _mapper.Map<Divida>(newDivida);
            divida.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());
            divida.DataPagamento = null;
            divida.SituacaoDivida = SituacaoDivida.Ativa;
            _context.Dividas.Add(divida);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId())
                .Select(c => _mapper.Map<GetDividaDto>(c))
                .ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetDividaDto>>> DeleteDivida(int contaId)
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            try
            {
                Divida divida = await _context.Dividas.FirstOrDefaultAsync(c => c.Id == contaId && c.Usuario.Id == GetUserId());
                if (divida != null)
                {
                    _context.Dividas.Remove(divida);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Dividas
                        .Where(c => c.Usuario.Id == GetUserId())
                        .Select(c => _mapper.Map<GetDividaDto>(c))
                        .ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Divida não encontrada";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetDividaDto>>> GetAllDividas()
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            List<Divida> dbDividas = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId())
                .Include(c => c.Usuario)
                .Include(c => c.Conta)
                .ToListAsync();
            response.Data = dbDividas.Select(c => _mapper.Map<GetDividaDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetDividaDto>> GetDividaById(int dividaId)
        {
            var serviceResponse = new ServiceResponse<GetDividaDto>();
            var dbConta = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId())
                .Include(c => c.Conta)
                .FirstOrDefaultAsync(c => c.Id == dividaId && c.Usuario.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetDividaDto>(dbConta);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDividaDto>> UpdateDivida(UpdateDividaDto updatedDivida)
        {
            ServiceResponse<GetDividaDto> response = new ServiceResponse<GetDividaDto>();
            try
            {
                var divida = await _context.Dividas
                    .Include(c => c.Usuario)
                    .Include(c => c.Conta)
                    .FirstOrDefaultAsync(c => c.Id == updatedDivida.Id);

                if (divida.Usuario.Id == GetUserId())
                {
                    divida.Titulo = updatedDivida.Titulo;
                    divida.NomeDevedor = updatedDivida.NomeDevedor;
                    divida.Descricao = updatedDivida.Descricao;
                    divida.Valor = updatedDivida.Valor;
                    divida.DataPagamento = updatedDivida.DataPagamento;
                    divida.DataVencimento = updatedDivida.DataVencimento;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetDividaDto>(divida);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Dívida não encontrada";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetDividaDto>>> PagarDivida(int dividaId, PagarDividaDto pagarDividaDto)
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            try
            {
                Divida divida = await _context.Dividas.FirstOrDefaultAsync(c => c.Id == dividaId && c.Usuario.Id == GetUserId());
                Conta conta = await _context.Contas.FirstOrDefaultAsync(c => c.Id == pagarDividaDto.ContaId && c.Usuario.Id == GetUserId());
                if (divida != null)
                {
                    Operacao newOperacao = new Operacao
                    {
                        Titulo = divida.Titulo,
                        Valor = divida.Valor,
                        DataOperacao = pagarDividaDto.DataPagamento,
                        Descricao = divida.Descricao,
                        Conta = conta,
                    };
                    if (divida.TipoDivida == TipoDivida.Gasto)
                    {
                        newOperacao.TipoOperacao = TipoOperacao.Gasto;
                    }
                    else
                    {
                        newOperacao.TipoOperacao = TipoOperacao.Recebimento;
                    }
                    if (divida.TipoDivida == TipoDivida.Gasto)
                    {
                        conta.Saldo -= divida.Valor;
                    }
                    else
                    {
                        conta.Saldo += divida.Valor;
                    }
                    divida.DataPagamento = pagarDividaDto.DataPagamento;
                    divida.SituacaoDivida = SituacaoDivida.Paga;
                    divida.Conta = conta;
                    _context.Operacoes.Add(newOperacao);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Dividas
                        .Where(c => c.Usuario.Id == GetUserId())
                        .Include(c => c.Conta)
                        .Select(c => _mapper.Map<GetDividaDto>(c))
                        .ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Divida não encontrada";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetDividaDto>>> GetDividasAPagar()
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            List<Divida> dbDividas = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId())
                .Where(c => c.TipoDivida == TipoDivida.Gasto)
                .Where(c => c.SituacaoDivida == SituacaoDivida.Ativa)
                .Include(c => c.Conta)
                .Include(c => c.Usuario)
                .ToListAsync();
            response.Data = dbDividas.Select(c => _mapper.Map<GetDividaDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetDividaDto>>> GetDividasAReceber()
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            List<Divida> dbDividas = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId())
                .Where(c => c.TipoDivida == TipoDivida.Recebimento)
                .Where(c => c.SituacaoDivida == SituacaoDivida.Ativa)
                .Include(c => c.Conta)
                .Include(c => c.Usuario)
                .ToListAsync();
            response.Data = dbDividas.Select(c => _mapper.Map<GetDividaDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetDividaDto>>> GetDividasPagas()
        {
            ServiceResponse<List<GetDividaDto>> response = new ServiceResponse<List<GetDividaDto>>();
            List<Divida> dbDividas = await _context.Dividas
                .Where(c => c.Usuario.Id == GetUserId() && c.SituacaoDivida == SituacaoDivida.Paga)
                .Include(c => c.Conta)
                .Include(c => c.Usuario)
                .ToListAsync();
            response.Data = dbDividas.Select(c => _mapper.Map<GetDividaDto>(c)).ToList();
            return response;
        }
    }
}
