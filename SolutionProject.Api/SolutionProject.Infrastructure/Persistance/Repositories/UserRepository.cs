using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;
namespace SolutionProject.Infrastructure.Persistance.Repositories
{
    public class UserRepository : EfRepository<User>, IRepository<User>, IUserRepository
    {
        private readonly ApplicationDBContext dbContext;

        public UserRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
