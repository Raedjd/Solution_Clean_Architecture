using AutoMapper;
using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.DataTransfertObject;

namespace SolutionProject.Application.Feature.Users.Queries.GetListUsers
{
    public class GetUsersListQueryHandler :ResponseHandler, IRequestHandler<GetUsersListQuery, Response<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<UserDto>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.ListAsync(cancellationToken);
            var userListMapper = _mapper.Map<List<UserDto>>(userList);
            return Success(userListMapper);
        }
    }
}
