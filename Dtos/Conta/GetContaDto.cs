using CarteiraDigitalAPI.Dtos.Usuario;

namespace CarteiraDigitalAPI.Dtos.Conta
{
    public class GetContaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public string Banco { get; set; }
        public GetUsuarioDto Usuario { get; set; }
    }
}
