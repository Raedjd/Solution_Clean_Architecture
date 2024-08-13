using SolutionProject.Application.Contracts.Persistance;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Infrastructure.Persistance.Repositories
{
    public class RoleRepository : EfRepository<Role>, IRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public RoleRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ExistsAsync(Guid roleId)
        {
            return _dbContext.Roles.Any(r => r.Id == roleId);
        }
    }
}
