namespace CarteiraDigitalAPI.Dtos.Planejamento
{
    public class AddPlanejamentoDto
    {
        public string Titulo { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorPlanejado { get; set; }
        public bool IsExcedido { get; set; }
    }
}
