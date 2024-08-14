using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.Contracts.Persistence;

namespace SolutionProject.Application.Feature.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetByIdAsync(request.Id);
            if (userExists == null)
            {
                return NotFound<string>("User not found");
            }
            await _userRepository.DeleteAsync(userExists);
            return Deleted<string>();
        }
    }
}
