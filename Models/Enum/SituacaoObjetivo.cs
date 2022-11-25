using System.Text.Json.Serialization;

namespace CarteiraDigitalAPI.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SituacaoObjetivo
    {
        Não_Cumprido = 1,
        Cumprido = 2
    }
}
