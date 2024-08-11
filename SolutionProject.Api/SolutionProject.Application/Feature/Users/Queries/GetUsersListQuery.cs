using MediatR;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Feature.Users.Queries
{
    public class GetUsersListQuery : IRequest<List<User>>
    {
    }
}
