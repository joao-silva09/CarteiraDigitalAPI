using System.Text.Json.Serialization;

namespace CarteiraDigitalAPI.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoOperacao
    {
        Gasto = 1,
        Recebimento = 2,
        Transferência = 3
    }
}
