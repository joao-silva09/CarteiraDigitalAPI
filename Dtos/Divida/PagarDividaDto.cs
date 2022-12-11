using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Divida
{
    public class PagarDividaDto
    {
        public int? ContaId { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
