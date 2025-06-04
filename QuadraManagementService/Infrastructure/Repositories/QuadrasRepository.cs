using Microsoft.EntityFrameworkCore;
using QuadraManagementService.Entities;
using QuadraManagementService.Infrastructure.Context;
using QuadraManagementService.Infrastructure.Repositories.Contracts;

namespace QuadraManagementService.Infrastructure.Repositories
{
    public class QuadrasRepository : IQuadrasRepository
    {
        private readonly SqlContext _sqlContext;

        public QuadrasRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IQueryable<Quadras> GetAllReadOnly() => _sqlContext.Quadras.AsNoTracking();

        public async Task<Quadras> GetByIdAsync(int id) => await _sqlContext.Quadras.FindAsync(id);

        public async Task AddAsync(Quadras entity)
        {
            await _sqlContext.AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }
    }
}
