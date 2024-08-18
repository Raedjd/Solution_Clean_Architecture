using AutoMapper;
using FluentValidation;
using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.Contracts.Identity;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Application.Feature.Users.Commands.AddUser
{
    public class AddUserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddUserCommand> _validator;
        private readonly IPasswordHasher _passwordHasher;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper,IValidator<AddUserCommand> validator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }
        public async Task<Response<Guid>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {   
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) {
                return BadRequestValidation<Guid>(validationResult.Errors);
            }
            // Hash the password
            var passwordHash = _passwordHasher.HashPassword(request.Password);
            var userMapper = _mapper.Map<User>(request);
            userMapper.PasswordHashed = passwordHash;
            var userAdded = await _userRepository.AddAsync(userMapper);
             return Created(userAdded.Id);
        }
    }
}
