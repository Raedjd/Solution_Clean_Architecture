using Microsoft.EntityFrameworkCore;
using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Domain.Common;

namespace SolutionProject.Infrastructure.Persistance
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;

        public EfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async  Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Update(entity);

            await SaveChangesAsync(cancellationToken);
        }
    }
}
