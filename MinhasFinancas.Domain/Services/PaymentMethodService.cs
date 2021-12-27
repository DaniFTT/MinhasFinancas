using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;

namespace MinhasFinancas.Domain.Services
{
    internal class PaymentMethodService : BaseService<PaymentMethod>
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
