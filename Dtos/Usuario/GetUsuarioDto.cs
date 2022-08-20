using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Dtos.Divida;

namespace CarteiraDigitalAPI.Dtos.Usuario
{
    public class GetUsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Objetivo> Objetivos { get; set; }
        public List<GetContaDto> Contas { get; set; }
        public List<GetDividaDto> Dividas { get; set; }
        public List<Operacao> Operacoes { get; set; }
    }
}
