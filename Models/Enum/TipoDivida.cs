using System.Text.Json.Serialization;

namespace CarteiraDigitalAPI.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoDivida
    {
        Gasto = 1,
        Recebimento = 2
    }
}
