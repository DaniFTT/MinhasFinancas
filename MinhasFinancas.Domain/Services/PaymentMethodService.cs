using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Domain.Services
{
    public class PaymentMethodService : BaseService<PaymentMethod>, IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodService(IBaseRepository<PaymentMethod> baseRepository, IPaymentMethodRepository paymentMethodRepository) : base(baseRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public override Task<PaymentMethod> Add<TValidator>(PaymentMethod obj)
        {
            return base.Add<TValidator>(obj);
        }
    }
}
