namespace CarteiraDigitalAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        public List<Operacao> Operacoes { get; set; }
        public List<Orcamento> Orcamentos { get; set; }
    }
}
