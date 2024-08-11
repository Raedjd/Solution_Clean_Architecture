using SolutionProject.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
