using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsByEmailAsync(string mail);
    }
}
