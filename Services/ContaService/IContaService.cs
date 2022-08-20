using CarteiraDigitalAPI.Dtos.Conta;

namespace CarteiraDigitalAPI.Services.ContaService
{
    public interface IContaService
    {
        Task<ServiceResponse<List<GetContaDto>>> GetAllContas();
        Task<ServiceResponse<GetContaDto>> GetContaById(int contaId);
        Task<ServiceResponse<List<GetContaDto>>> AddConta(AddContaDto newConta);
        Task<ServiceResponse<GetContaDto>> UpdateConta(AddContaDto newConta);
        Task<ServiceResponse<List<GetContaDto>>> DeleteConta(int contaId);
    }
}
