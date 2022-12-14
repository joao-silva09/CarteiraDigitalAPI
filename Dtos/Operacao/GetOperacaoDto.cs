using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Operacao
{
    public class GetOperacaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public GetContaDto Conta { get; set; }
    }
}
