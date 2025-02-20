using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.DataTransfertObject;
namespace SolutionProject.Application.Feature.Users.Queries.GetListUsers
{
    public class GetUsersListQuery : IRequest<Response<List<UserDto>>>
    {
    }
}
