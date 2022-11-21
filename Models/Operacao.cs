using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Models
{
    public class Operacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string DataOperacao { get; set; }
        public TipoDivida TipoDivida { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public Conta? Conta { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
