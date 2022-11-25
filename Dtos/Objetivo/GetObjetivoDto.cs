using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Objetivo
{
    public class GetObjetivoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public SituacaoObjetivo SituacaoObjetivo { get; set; }
        public GetContaDto? Conta { get; set; }

    }
}
