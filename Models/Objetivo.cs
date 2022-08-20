namespace CarteiraDigitalAPI.Models
{
    public class Objetivo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsCumprido { get; set; }
        public Usuario Usuario { get; set; }
    }
}
