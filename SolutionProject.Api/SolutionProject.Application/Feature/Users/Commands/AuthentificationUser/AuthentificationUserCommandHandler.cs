using AutoMapper;
using MediatR;
using SolutionProject.Application.Contracts.Identity;
using SolutionProject.Application.DataTransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Feature.Users.Commands.AuthentificationUser
{
    public class AuthentificationUserCommandHandler : IRequestHandler<AuthentificationUserCommand, AuthenticationResultDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
       private readonly IMapper _mapper;

        public AuthentificationUserCommandHandler(
            IAuthenticationService authenticationService,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper
            )
        {
            _authenticationService = authenticationService;
            _jwtTokenGenerator = jwtTokenGenerator;
           _mapper = mapper;
        }
        public async Task<AuthenticationResultDto> Handle(AuthentificationUserCommand request, CancellationToken cancellationToken)
        {
            // Authenticate the user using the email and password
            var user = await _authenticationService.AuthenticateAsync(request.Email, request.Password);
            if (user == null)
            {
                return new AuthenticationResultDto
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Authentication failed. Incorrect username or password."
                };
            }
            var userResponse = _mapper.Map<UserDto>(user);
            // Generate a JWT token
            var token = _jwtTokenGenerator.GenerateToken(user, user.Role.Name!);
            return new AuthenticationResultDto
            {
                User = userResponse,
                IsAuthSuccessful = true,
                Token = token
            };
        }
    }
}
