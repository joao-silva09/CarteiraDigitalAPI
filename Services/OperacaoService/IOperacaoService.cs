using CarteiraDigitalAPI.Dtos.Operacao;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Services.OperacaoService
{
    public interface IOperacaoService
    {
        Task<ServiceResponse<List<GetOperacaoDto>>> GetAllOperacoes();
        Task<ServiceResponse<List<GetOperacaoDto>>> GetOperacoesByMonth(int month, int year);
        Task<ServiceResponse<List<GetOperacaoDto>>> GetOperacoesByMonthAndType(int month, int year, TipoOperacao? type);
        Task<ServiceResponse<GetOperacaoDto>> GetOperacaoById(int operacaoId);
        Task<ServiceResponse<List<GetOperacaoDto>>> GetOperacoesByConta(int contaId);
        Task<ServiceResponse<List<GetOperacaoDto>>> AddReceita(AddOperacaoDto newOperacao, int contaId);
        Task<ServiceResponse<List<GetOperacaoDto>>> AddGasto(AddOperacaoDto newOperacao, int contaId);
        Task<ServiceResponse<List<GetOperacaoDto>>> AddOperacao(AddOperacaoDto newOperacao, int contaId);
        Task<ServiceResponse<GetOperacaoDto>> UpdateOperacao(UpdateOperacaoDto updatedOperacao);
        Task<ServiceResponse<List<GetOperacaoDto>>> DeleteOperacao(int operacaoId);
    }
}
