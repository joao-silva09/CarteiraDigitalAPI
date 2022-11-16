using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Models
{
    public class Divida
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeDevedor { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public TipoDivida TipoDivida { get; set; }
        public SituacaoDivida SituacaoDivida { get; set; }
        public Conta? Conta { get; set; }
        public Usuario Usuario { get; set; }
    }
}
