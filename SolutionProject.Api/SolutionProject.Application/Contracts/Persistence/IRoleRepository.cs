using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Contracts.Persistence
{
       public interface IRoleRepository :  IRepository<Role>
    {
        Task<bool> ExistsAsync(Guid roleId);
    }
}
