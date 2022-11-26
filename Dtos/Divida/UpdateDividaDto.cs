using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Divida
{
    public class UpdateDividaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeDevedor { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public TipoDivida TipoDivida { get; set; }
    }
}
