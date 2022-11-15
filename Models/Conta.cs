using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Saldo { get; set; }
        public Banco Banco { get; set; }
        public Usuario Usuario { get; set; }
        public List<Divida>? Dividas { get; set; }
        public List<Operacao>? Operacoes { get; set; }
    }
}
