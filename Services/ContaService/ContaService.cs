using AutoMapper;
using CarteiraDigitalAPI.Data;
using CarteiraDigitalAPI.Dtos.Conta;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Services.ContaService
{
    public class ContaService : IContaService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContaService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetContaDto>>> AddConta(AddContaDto newConta)
        {

            var serviceResponse = new ServiceResponse<List<GetContaDto>>();
            Conta conta = _mapper.Map<Conta>(newConta);
            conta.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Contas
                .Where(c => c.Id == GetUserId())
                .Select(c => _mapper.Map<GetContaDto>(c))
                .ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetContaDto>>> DeleteConta(int contaId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetContaDto>>> GetAllContas()
        {
            var response = new ServiceResponse<List<GetContaDto>>();
            var dbCharacters = await _context.Contas
                .Where(c => c.Usuario.Id == GetUserId())
                .ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetContaDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetContaDto>> GetContaById(int contaId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetContaDto>> UpdateConta(AddContaDto newConta)
        {
            throw new NotImplementedException();
        }
    }
}
