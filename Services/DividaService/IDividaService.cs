using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Dtos.Divida;

namespace CarteiraDigitalAPI.Services.DividaService
{
    public interface IDividaService
    {
        Task<ServiceResponse<List<GetDividaDto>>> GetAllDividas();
        Task<ServiceResponse<GetDividaDto>> GetDividaById(int dividaID);
        Task<ServiceResponse<List<GetDividaDto>>> AddDivida(AddDividaDto newDivida);
        Task<ServiceResponse<GetDividaDto>> UpdateDivida(UpdateDividaDto updatedDivida);
        Task<ServiceResponse<List<GetDividaDto>>> DeleteDivida(int dividaId);
    }
}
