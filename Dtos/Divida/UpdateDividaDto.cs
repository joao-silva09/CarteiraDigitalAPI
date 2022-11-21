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
        public string DataVencimento { get; set; }
        public string DataPagamento { get; set; }
        public TipoDivida TipoDivida { get; set; }
    }
}
