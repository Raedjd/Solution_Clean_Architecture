using Microsoft.EntityFrameworkCore;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() {
        
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
