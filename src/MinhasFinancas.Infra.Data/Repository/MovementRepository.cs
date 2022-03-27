using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class MovementRepository : BaseRepository<Movement>, IMovementRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public MovementRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }
    }
}
