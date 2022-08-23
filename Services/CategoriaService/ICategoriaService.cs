using CarteiraDigitalAPI.Dtos.Categoria;
using CarteiraDigitalAPI.Dtos.Conta;

namespace CarteiraDigitalAPI.Services.CategoriaService
{
    public interface ICategoriaService
    {
        Task<ServiceResponse<List<GetCategoriaDto>>> GetAllCategorias();
        Task<ServiceResponse<GetCategoriaDto>> GetCategoriaById(int categoriaId);
        Task<ServiceResponse<List<GetCategoriaDto>>> AddCategoria(AddCategoriaDto newCategoria);
        Task<ServiceResponse<GetCategoriaDto>> UpdateCategoria(UpdateCategoriaDto newCategoria);
        Task<ServiceResponse<List<GetCategoriaDto>>> DeleteCategoria(int categoriaId);
    }
}
