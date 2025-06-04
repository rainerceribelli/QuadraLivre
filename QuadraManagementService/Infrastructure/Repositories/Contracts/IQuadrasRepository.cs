using QuadraManagementService.Entities;
using QuadraManagementService.Infrastructure.Context;

namespace QuadraManagementService.Infrastructure.Repositories.Contracts
{
    public interface IQuadrasRepository
    {
        public IQueryable<Quadras> GetAllReadOnly();

        public Task<Quadras> GetByIdAsync(int id);

        Task AddAsync(Quadras entity);

        Task CommitAsync();
    }
}
