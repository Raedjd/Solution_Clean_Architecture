using AutoMapper;
using MediatR;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.DataTransfertObject;

namespace SolutionProject.Application.Feature.Users.Queries.GetListUsers
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.ListAsync(cancellationToken);
            var userListMapper = _mapper.Map<List<UserDto>>(userList);
            return userListMapper;
        }
    }
}
