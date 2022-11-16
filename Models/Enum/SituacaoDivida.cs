using System.Text.Json.Serialization;

namespace CarteiraDigitalAPI.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SituacaoDivida
    {
        Ativa = 1,
        Paga = 2
    }
}
