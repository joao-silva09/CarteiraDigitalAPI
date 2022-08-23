using CarteiraDigitalAPI.Dtos.Objetivo;

namespace CarteiraDigitalAPI.Services.ObjetivoService
{
    public interface IObjetivoService
    {
        Task<ServiceResponse<List<GetObjetivoDto>>> GetAllObjetivos();
        Task<ServiceResponse<GetObjetivoDto>> GetObjetivoById(int objetivoId);
        Task<ServiceResponse<List<GetObjetivoDto>>> AddObjetivo(AddObjetivoDto newObjetivo);
        Task<ServiceResponse<GetObjetivoDto>> UpdateObjetivo(UpdateObjetivoDto newObjetivo);
        Task<ServiceResponse<List<GetObjetivoDto>>> DeleteObjetivo(int objetivoId);
    }
}
