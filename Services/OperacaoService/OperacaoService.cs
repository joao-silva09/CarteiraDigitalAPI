using AutoMapper;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Operacao;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Services.OperacaoService
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public OperacaoService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetOperacaoDto>>> AddOperacao(AddOperacaoDto newOperacao)
        {
            var serviceResponse = new ServiceResponse<List<GetOperacaoDto>>();
            Operacao operacao = _mapper.Map<Operacao>(newOperacao);
            operacao.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Operacoes.Add(operacao);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Operacoes
                .Where(c => c.Id == GetUserId())
                .Select(c => _mapper.Map<GetOperacaoDto>(c))
                .ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetOperacaoDto>>> DeleteOperacao(int operacaoId)
        {
            ServiceResponse<List<GetOperacaoDto>> response = new ServiceResponse<List<GetOperacaoDto>>();
            try
            {
                Operacao operacao = await _context.Operacoes.FirstOrDefaultAsync(c => c.Id == operacaoId && c.Usuario.Id == GetUserId());
                if (operacao != null)
                {
                    _context.Operacoes.Remove(operacao);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Operacoes
                        .Where(c => c.Usuario.Id == GetUserId())
                        .Select(c => _mapper.Map<GetOperacaoDto>(c))
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

        public async Task<ServiceResponse<List<GetOperacaoDto>>> GetAllOperacoes()
        {
            var response = new ServiceResponse<List<GetOperacaoDto>>();
            var dbOperacoes = await _context.Operacoes
                .Where(c => c.Usuario.Id == GetUserId())
                .ToListAsync();
            response.Data = dbOperacoes.Select(c => _mapper.Map<GetOperacaoDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetOperacaoDto>> GetOperacaoById(int operacaoId)
        {
            var serviceResponse = new ServiceResponse<GetOperacaoDto>();
            var dbOperacoes = await _context.Operacoes
                .Where(c => c.Usuario.Id == GetUserId())
                .FirstOrDefaultAsync(c => c.Id == operacaoId && c.Usuario.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetOperacaoDto>(dbOperacoes);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOperacaoDto>> UpdateOperacao(UpdateOperacaoDto updatedDivida)
        {
            ServiceResponse<GetOperacaoDto> response = new ServiceResponse<GetOperacaoDto>();
            try
            {
                var divida = await _context.Dividas
                    .Include(c => c.Usuario)
                    .FirstOrDefaultAsync(c => c.Id == updatedDivida.Id);

                if (divida.Usuario.Id == GetUserId())
                {
                    divida.Titulo = updatedDivida.Titulo;
                    divida.NomeDevedor = updatedDivida.NomeDevedor;
                    divida.Descricao = updatedDivida.Descricao;
                    divida.Valor = updatedDivida.Valor;
                    divida.DataDivida = updatedDivida.DataDivida;
                    divida.DataVencimento = updatedDivida.DataVencimento;
                    divida.IsAtivo = updatedDivida.IsAtivo;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetOperacaoDto>(divida);
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
    }
}
