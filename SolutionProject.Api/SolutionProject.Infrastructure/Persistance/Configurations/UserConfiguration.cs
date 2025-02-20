using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SolutionProject.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                     .HasOne(u => u.Role)
                     .WithMany(r => r.Users)
                     .HasForeignKey(u => u.RoleId);
        }
    }
}
