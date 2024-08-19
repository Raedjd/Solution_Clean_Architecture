using Microsoft.EntityFrameworkCore;
using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;
namespace SolutionProject.Infrastructure.Persistance.Repositories
{
    public class UserRepository : EfRepository<User>, IRepository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetByEmailAsync(string mail)
        {
            return await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.Email.ToLower() == mail.ToLower());
        }
    }
}
