using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Domain.Services
{
    public class WalletService : BaseService<Wallet>, IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IBaseRepository<Wallet> baseRepository, IWalletRepository walletRepository) : base(baseRepository)
        {
            _walletRepository = walletRepository;
        }

        public override async Task<Wallet> Add(Wallet obj)
        {
            return await base.Add(obj);
        }
    }
}
