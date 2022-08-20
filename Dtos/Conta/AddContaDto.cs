namespace CarteiraDigitalAPI.Dtos.Conta
{
    public class AddContaDto
    {
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public string Banco { get; set; }
        public int UsuarioId { get; set; }
    }
}
