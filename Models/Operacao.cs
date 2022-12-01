using CarteiraDigitalAPI.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraDigitalAPI.Models
{
    public class Operacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataOperacao { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public Conta? Conta { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
