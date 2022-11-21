using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Operacao
{
    public class AddOperacaoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string DataOperacao { get; set; }
        public TipoDivida TipoDivida { get; set; }
    }
}
