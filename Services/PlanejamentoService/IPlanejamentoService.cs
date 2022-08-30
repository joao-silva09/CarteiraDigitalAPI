using CarteiraDigitalAPI.Dtos.Objetivo;
using CarteiraDigitalAPI.Dtos.Planejamento;

namespace CarteiraDigitalAPI.Services.PlanejamentoService
{
    public interface IPlanejamentoService
    {
        Task<ServiceResponse<List<GetPlanejamentoDto>>> GetAllPlanejamentos();
        Task<ServiceResponse<GetPlanejamentoDto>> GetPlanejamentoById(int planejamentoId);
        Task<ServiceResponse<List<GetPlanejamentoDto>>> AddPlanejamento(AddPlanejamentoDto newPlanejamento);
        Task<ServiceResponse<GetPlanejamentoDto>> UpdatePlanejamento(UpdatePlanejamentoDto newPlanejamento);
        Task<ServiceResponse<List<GetPlanejamentoDto>>> DeletePlanejamento(int planejamentoId);
    }
}
