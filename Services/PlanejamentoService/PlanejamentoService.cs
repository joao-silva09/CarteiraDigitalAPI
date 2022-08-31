using AutoMapper;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Objetivo;
using CarteiraDigitalAPI.Dtos.Planejamento;
using CarteiraDigitalAPI.Services.PlanejamentoService;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Services.PlanejamentoService
{
    public class PlanejamentoService : IPlanejamentoService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlanejamentoService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetPlanejamentoDto>>> AddPlanejamento(AddPlanejamentoDto newPlanejamento)
        {
            var serviceResponse = new ServiceResponse<List<GetPlanejamentoDto>>();
            Planejamento planejamento = _mapper.Map<Planejamento>(newPlanejamento);
            planejamento.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Planejamentos.Add(planejamento);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Planejamentos
                .Where(c => c.Id == GetUserId())
                .Select(c => _mapper.Map<GetPlanejamentoDto>(c))
                .ToListAsync();
            serviceResponse.Message = "Planejamento adicionado com sucesso!";
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetPlanejamentoDto>>> DeletePlanejamento(int planejamentoId)
        {
            ServiceResponse<List<GetPlanejamentoDto>> response = new ServiceResponse<List<GetPlanejamentoDto>>();
            try
            {
                Planejamento planejamento = await _context.Planejamentos.FirstOrDefaultAsync(c => c.Id == planejamentoId && c.Usuario.Id == GetUserId());
                if (planejamento != null)
                {
                    _context.Planejamentos.Remove(planejamento);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Planejamentos
                        .Where(c => c.Usuario.Id == GetUserId())
                        .Select(c => _mapper.Map<GetPlanejamentoDto>(c))
                        .ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Planejamento não encontrado";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPlanejamentoDto>>> GetAllPlanejamentos()
        {
            var response = new ServiceResponse<List<GetPlanejamentoDto>>();
            var dbplanejamentos = await _context.Planejamentos
                .Where(c => c.Usuario.Id == GetUserId())
                .ToListAsync();
            response.Data = dbplanejamentos.Select(c => _mapper.Map<GetPlanejamentoDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetPlanejamentoDto>> GetPlanejamentoById(int planejamentoId)
        {
            var serviceResponse = new ServiceResponse<GetPlanejamentoDto>();
            var dbplanejamentos = await _context.Planejamentos
                .Where(c => c.Usuario.Id == GetUserId())
                .FirstOrDefaultAsync(c => c.Id == planejamentoId && c.Usuario.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetPlanejamentoDto>(dbplanejamentos);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlanejamentoDto>> UpdatePlanejamento(UpdatePlanejamentoDto updatedPlanejamento)
        {
            ServiceResponse<GetPlanejamentoDto> response = new ServiceResponse<GetPlanejamentoDto>();
            try
            {
                var planejamento = await _context.Planejamentos
                    .Include(c => c.Usuario)
                    .FirstOrDefaultAsync(c => c.Id == updatedPlanejamento.Id);

                if (planejamento.Usuario.Id == GetUserId())
                {
                    planejamento.Titulo = updatedPlanejamento.Titulo;
                    planejamento.ValorInicial = updatedPlanejamento.ValorInicial;
                    planejamento.ValorPlanejado = updatedPlanejamento.ValorPlanejado;
                    planejamento.IsExcedido = updatedPlanejamento.IsExcedido;

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetPlanejamentoDto>(planejamento);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Planejamento não encontrado";
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
