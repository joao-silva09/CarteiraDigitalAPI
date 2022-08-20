namespace CarteiraDigitalAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Usuario usuario, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
