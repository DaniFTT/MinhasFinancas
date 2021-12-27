using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public WalletRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }
    }
}
