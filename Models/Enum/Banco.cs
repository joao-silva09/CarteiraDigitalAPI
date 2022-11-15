using System.Text.Json.Serialization;

namespace CarteiraDigitalAPI.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Banco
    {
        Bradesco = 1,
        Itaú = 2,
        Santander = 3,
        Banco_Do_Brasil = 4,
        Caixa = 5,
        Sicredi = 6,
        Sicoob = 7,
        Nubank = 8,
        Inter = 9,
        C6_bank = 10,
        PicPay = 11,
        Carteira_Pessoal = 12,
        Outros = 13
    }
}
