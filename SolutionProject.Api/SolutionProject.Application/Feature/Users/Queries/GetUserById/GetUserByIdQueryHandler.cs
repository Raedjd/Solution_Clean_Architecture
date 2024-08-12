
using AutoMapper;
using MediatR;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.DataTransfertObject;

namespace SolutionProject.Application.Feature.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {  
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                return null;
            }
            var userResponse = _mapper.Map<UserDto>(user);
            return userResponse;
        }
    }
}
