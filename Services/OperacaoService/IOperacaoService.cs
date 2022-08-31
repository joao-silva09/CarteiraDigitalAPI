using CarteiraDigitalAPI.Dtos.Operacao;
using CarteiraDigitalAPI.Dtos.Planejamento;

namespace CarteiraDigitalAPI.Services.OperacaoService
{
    public interface IOperacaoService
    {
        Task<ServiceResponse<List<GetOperacaoDto>>> GetAllOperacoes();
        Task<ServiceResponse<GetOperacaoDto>> GetOperacaoById(int operacaoId);
        Task<ServiceResponse<List<GetOperacaoDto>>> AddOperacap(AddOperacaoDto newOperacao);
        Task<ServiceResponse<GetOperacaoDto>> UpdateOperacao(UpdateOperacaoDto updatedOperacao);
        Task<ServiceResponse<List<GetOperacaoDto>>> DeleteOperacao(int operacaoId);
    }
}
