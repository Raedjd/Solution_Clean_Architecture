using MediatR;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Feature.Users.Queries.GetListUsers
{
    public class GetUsersListQuery : IRequest<List<User>>
    {
    }
}
