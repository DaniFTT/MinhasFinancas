using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public PaymentMethodRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }
    }
}
