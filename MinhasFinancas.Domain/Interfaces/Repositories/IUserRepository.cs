namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<string> RetornaIdUsuario(string email);
    }
}
