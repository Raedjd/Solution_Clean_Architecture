using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() {
        
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {

            // For Docker: Ensure the database is created
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            if (databaseCreator != null)
            {
                // Check if the database exists and create it if it doesn't
                if (!databaseCreator.CanConnect())
                {
                    databaseCreator.Create();
                }

                // Optionally, apply any pending migrations
                if (!databaseCreator.HasTables())
                {
                    databaseCreator.CreateTables();
                }
            }

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
