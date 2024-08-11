namespace SolutionProject.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
