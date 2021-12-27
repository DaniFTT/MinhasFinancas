namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> RetornaIdUsuario(string email);
    }
}
