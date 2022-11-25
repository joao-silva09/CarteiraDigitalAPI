using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Models.Enum;

namespace CarteiraDigitalAPI.Dtos.Objetivo
{
    public class AddObjetivoDto
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public SituacaoObjetivo SituacaoObjetivo { get; set; }
    }

}
