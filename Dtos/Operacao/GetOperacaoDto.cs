using CarteiraDigitalAPI.Dtos.Conta;

namespace CarteiraDigitalAPI.Dtos.Operacao
{
    public class GetOperacaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao { get; set; }
        public bool IsGasto { get; set; }
        public GetContaDto Conta { get; set; }
    }
}
