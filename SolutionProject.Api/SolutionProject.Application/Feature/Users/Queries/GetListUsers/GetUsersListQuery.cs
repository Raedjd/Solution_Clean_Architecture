using MediatR;
using SolutionProject.Application.DataTransfertObject;
namespace SolutionProject.Application.Feature.Users.Queries.GetListUsers
{
    public class GetUsersListQuery : IRequest<List<UserDto>>
    {
    }
}
