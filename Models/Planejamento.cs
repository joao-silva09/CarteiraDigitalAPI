namespace CarteiraDigitalAPI.Models
{
    public class Planejamento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorPlanejado { get; set; }
        public bool IsExcedido { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
