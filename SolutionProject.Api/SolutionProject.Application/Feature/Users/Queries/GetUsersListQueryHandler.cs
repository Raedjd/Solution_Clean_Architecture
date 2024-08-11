using MediatR;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Feature.Users.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
           return await _userRepository.ListAsync(cancellationToken);
        }
    }
}
