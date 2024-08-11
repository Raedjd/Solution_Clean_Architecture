using SolutionProject.Domain.Common;

namespace SolutionProject.Domain.Entities
{
   public class Role : BaseEntity
    {
        public Role()
        {
            this.Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
