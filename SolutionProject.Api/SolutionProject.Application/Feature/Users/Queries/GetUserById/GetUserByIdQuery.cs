using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.DataTransfertObject;


namespace SolutionProject.Application.Feature.Users.Queries.GetUserById
{
 public class GetUserByIdQuery : IRequest<Response<UserDto>>
    {
        public Guid Id { get; set; }
    }
}
