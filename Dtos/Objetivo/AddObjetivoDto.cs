namespace CarteiraDigitalAPI.Dtos.Objetivo
{
    public class AddObjetivoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsCumprido { get; set; }
    }
}
