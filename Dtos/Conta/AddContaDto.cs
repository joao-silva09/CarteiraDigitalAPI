using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Conta
{
    public class AddContaDto
    {
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public Banco Banco { get; set; }
    }
}
