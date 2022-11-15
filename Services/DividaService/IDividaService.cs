using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Services.DividaService
{
    public interface IDividaService
    {
        Task<ServiceResponse<List<GetDividaDto>>> GetAllDividas();
        Task<ServiceResponse<List<GetDividaDto>>> GetDividasAPagar();
        Task<ServiceResponse<List<GetDividaDto>>> GetDividasAReceber();
        Task<ServiceResponse<List<GetDividaDto>>> GetDividasPagas();
        Task<ServiceResponse<GetDividaDto>> GetDividaById(int dividaID);
        Task<ServiceResponse<List<GetDividaDto>>> AddDivida(AddDividaDto newDivida);
        Task<ServiceResponse<GetDividaDto>> UpdateDivida(UpdateDividaDto updatedDivida);
        Task<ServiceResponse<List<GetDividaDto>>> DeleteDivida(int dividaId);
        Task<ServiceResponse<List<GetDividaDto>>> PagarDivida(int dividaId, int contaId);
    }
}
