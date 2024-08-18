using SolutionProject.Domain.Common;
namespace SolutionProject.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHashed { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
