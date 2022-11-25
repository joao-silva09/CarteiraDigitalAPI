using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Models
{
    public class Objetivo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public SituacaoObjetivo SituacaoObjetivo { get; set; }
        public Usuario Usuario { get; set; }
        public Conta? Conta { get; set; }
    }
}
