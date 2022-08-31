using CarteiraDigitalAPI.Dtos.Usuario;

namespace CarteiraDigitalAPI.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public string Banco { get; set; }
        public Usuario Usuario { get; set; }
        public List<Operacao>? Operacoes { get; set; }
    }
}
