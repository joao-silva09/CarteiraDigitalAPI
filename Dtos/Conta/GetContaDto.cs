using CarteiraDigitalAPI.Dtos.Usuario;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Conta
{
    public class GetContaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public Banco Banco { get; set; }
    }
}
