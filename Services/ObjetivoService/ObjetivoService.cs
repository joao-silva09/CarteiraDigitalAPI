using AutoMapper;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Objetivo;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Services.ObjetivoService
{
    public class ObjetivoService : IObjetivoService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ObjetivoService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetObjetivoDto>>> AddObjetivo(AddObjetivoDto newObjetivo)
        {
            var serviceResponse = new ServiceResponse<List<GetObjetivoDto>>();
            Objetivo objetivo = _mapper.Map<Objetivo>(newObjetivo);
            objetivo.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Objetivos.Add(objetivo);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Objetivos
                .Where(c => c.Id == GetUserId())
                .Select(c => _mapper.Map<GetObjetivoDto>(c))
                .ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetObjetivoDto>>> DeleteObjetivo(int objetivoId)
        {
            ServiceResponse<List<GetObjetivoDto>> response = new ServiceResponse<List<GetObjetivoDto>>();
            try
            {
                Objetivo objetivo = await _context.Objetivos.FirstOrDefaultAsync(c => c.Id == objetivoId && c.Usuario.Id == GetUserId());
                if (objetivo != null)
                {
                    _context.Objetivos.Remove(objetivo);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Objetivos
                        .Where(c => c.Usuario.Id == GetUserId())
                        .Select(c => _mapper.Map<GetObjetivoDto>(c))
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

        public async Task<ServiceResponse<List<GetObjetivoDto>>> GetAllObjetivos()
        {
            var response = new ServiceResponse<List<GetObjetivoDto>>();
            var dbObjetivos = await _context.Objetivos
                .Where(c => c.Usuario.Id == GetUserId())
                .ToListAsync();
            response.Data = dbObjetivos.Select(c => _mapper.Map<GetObjetivoDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetObjetivoDto>> GetObjetivoById(int objetivoId)
        {
            var serviceResponse = new ServiceResponse<GetObjetivoDto>();
            var dbObjetivos = await _context.Objetivos
                .Where(c => c.Usuario.Id == GetUserId())
                .FirstOrDefaultAsync(c => c.Id == objetivoId && c.Usuario.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetObjetivoDto>(dbObjetivos);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetObjetivoDto>> UpdateObjetivo(UpdateObjetivoDto updatedObjetivo)
        {
            ServiceResponse<GetObjetivoDto> response = new ServiceResponse<GetObjetivoDto>();
            try
            {
                var objetivo = await _context.Objetivos
                    .Include(c => c.Usuario)
                    .FirstOrDefaultAsync(c => c.Id == updatedObjetivo.Id);

                if (objetivo.Usuario.Id == GetUserId())
                {
                    objetivo.Titulo = updatedObjetivo.Titulo;
                    objetivo.Valor = updatedObjetivo.Valor;
                    objetivo.Descricao = updatedObjetivo.Descricao;
                    objetivo.IsCumprido = updatedObjetivo.IsCumprido;
                    
                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetObjetivoDto>(objetivo);
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
