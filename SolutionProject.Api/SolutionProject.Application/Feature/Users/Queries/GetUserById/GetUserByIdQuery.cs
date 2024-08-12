using MediatR;
using SolutionProject.Application.DataTransfertObject;


namespace SolutionProject.Application.Feature.Users.Queries.GetUserById
{
 public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
