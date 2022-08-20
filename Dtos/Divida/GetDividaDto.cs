namespace CarteiraDigitalAPI.Dtos.Divida
{
    public class GetDividaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeDevedor { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDivida { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsAtivo { get; set; }
    }
}
