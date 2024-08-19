using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionProject.Application.Contracts.Identity;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Domain.Entities;

namespace SolutionProject.Infrastructure.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            // Retrieve user by email
            var user = await _userRepository.GetByEmailAsync(email);

            // Check if user exists and verify password
            if (user != null && _passwordHasher.VerifyPassword(user, user.PasswordHashed, password))
            {
                return user;
            }

            // Authentication failed
            return null;
        }
    }
}
