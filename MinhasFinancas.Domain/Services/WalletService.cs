using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;

namespace MinhasFinancas.Domain.Services
{
    public class WalletService : BaseService<Wallet>
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IBaseRepository<Wallet> baseRepository, IWalletRepository walletRepository) : base(baseRepository)
        {
            _walletRepository = walletRepository;
        }

        public override async Task<Wallet> Add<TValidator>(Wallet obj)
        {
            return await base.Add<TValidator>(obj);
        }
    }
}
