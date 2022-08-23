//using AutoMapper;
//using CarteiraDigitalAPI.Data;
//using CarteiraDigitalAPI.Dtos.Categoria;
//using CarteiraDigitalAPI.Dtos.Conta;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace CarteiraDigitalAPI.Services.CategoriaService
//{
//    public class CategoriaService : ICategoriaService
//    {
//        private readonly IMapper _mapper;

//        private readonly DataContext _context;

//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public CategoriaService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
//        {
//            _mapper = mapper;
//            _context = context;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
//            .FindFirstValue(ClaimTypes.NameIdentifier));

//        public async Task<ServiceResponse<List<GetCategoriaDto>>> AddCategoria(AddCategoriaDto newCategoria)
//        {

//            var serviceResponse = new ServiceResponse<List<GetCategoriaDto>>();
//            Categoria categoria = _mapper.Map<Categoria>(newCategoria);
//            categoria.Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == GetUserId());

//            _context.Contas.Add(conta);
//            await _context.SaveChangesAsync();
//            serviceResponse.Data = await _context.Contas
//                .Where(c => c.Id == GetUserId())
//                .Select(c => _mapper.Map<GetCategoriaDto>(c))
//                .ToListAsync();
//            return serviceResponse;

//        }

//        public async Task<ServiceResponse<List<GetCategoriaDto>>> DeleteCategoria(int categoriaId)
//        {
//            ServiceResponse<List<GetCategoriaDto>> response = new ServiceResponse<List<GetCategoriaDto>>();
//            try
//            {
//                Conta conta = await _context.Contas.FirstOrDefaultAsync(c => c.Id == categoriaId && c.Usuario.Id == GetUserId());
//                if (conta != null)
//                {
//                    _context.Contas.Remove(conta);
//                    await _context.SaveChangesAsync();
//                    response.Data = _context.Contas
//                        .Where(c => c.Usuario.Id == GetUserId())
//                        .Select(c => _mapper.Map<GetCategoriaDto>(c))
//                        .ToList();
//                }
//                else
//                {
//                    response.Success = false;
//                    response.Message = "Conta não encontrada";
//                }
//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = ex.Message;
//            }
//            return response;
//        }

//        public async Task<ServiceResponse<List<GetCategoriaDto>>> GetAllCategorias()
//        {
//            var response = new ServiceResponse<List<GetCategoriaDto>>();
//            var dbCharacters = await _context.Contas
//                .Where(c => c.Usuario.Id == GetUserId())
//                .ToListAsync();
//            response.Data = dbCharacters.Select(c => _mapper.Map<GetCategoriaDto>(c)).ToList();
//            return response;
//        }

//        public async Task<ServiceResponse<GetCategoriaDto>> GetCategoriaById(int categoriaId)
//        {
//            var serviceResponse = new ServiceResponse<GetCategoriaDto>();
//            var dbConta = await _context.Contas
//                .Where(c => c.Usuario.Id == GetUserId())
//                .FirstOrDefaultAsync(c => c.Id == categoriaId && c.Usuario.Id == GetUserId());
//            serviceResponse.Data = _mapper.Map<GetCategoriaDto>(dbConta);
//            return serviceResponse;
//        }

//        public async Task<ServiceResponse<GetCategoriaDto>> UpdateCategoria(UpdateCategoriaDto updatedCategoria)
//        {
//            ServiceResponse<GetCategoriaDto> response = new ServiceResponse<GetCategoriaDto>();
//            try
//            {
//                var categoria = await _context.Categorias
//                    .Include(c => c.Usuario)
//                    .FirstOrDefaultAsync(c => c.Id == updatedCategoria.Id);

//                if (categoria.Usuario.Id == GetUserId())
//                {
//                    categoria.Titulo = updatedCategoria.Titulo;
//                    categoria.Banco = updatedCategoria.Cor;

//                    await _context.SaveChangesAsync();

//                    response.Data = _mapper.Map<GetCategoriaDto>(categoria);
//                }
//                else
//                {
//                    response.Success = false;
//                    response.Message = "Conta não encontrada";
//                }

//            }
//            catch (Exception ex)
//            {
//                response.Success = false;
//                response.Message = ex.Message;
//            }
//            return response;
//        }
//    }
//}

