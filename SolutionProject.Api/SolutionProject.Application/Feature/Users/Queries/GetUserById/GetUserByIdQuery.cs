using MediatR;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Feature.Users.Queries.GetUserById
{
 public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
