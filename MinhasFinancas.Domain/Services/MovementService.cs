using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Domain.Services
{
    public class MovementService : BaseService<Movement>, IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        public MovementService(IBaseRepository<Movement> baseRepository, IMovementRepository movementRepository) : base(baseRepository)
        {
            _movementRepository = movementRepository;
        }

        public override async Task<Movement> Add<TValidator>(Movement obj)
        {
            return await base.Add<TValidator>(obj);
        }
    }
}
