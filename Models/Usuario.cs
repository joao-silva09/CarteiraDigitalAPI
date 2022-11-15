namespace CarteiraDigitalAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Objetivo>? Objetivos { get; set; }
        public List<Conta>? Contas { get; set; }
        public List<Divida>? Dividas { get; set; }
    }
}
