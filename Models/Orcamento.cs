namespace CarteiraDigitalAPI.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public decimal ValorPlanejado { get; set; }
        public Categoria Categoria { get; set; }
    }
}
