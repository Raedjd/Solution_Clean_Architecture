using Microsoft.AspNetCore.Identity;
using SolutionProject.Application.Contracts.Identity;
using SolutionProject.Domain.Entities;


namespace SolutionProject.Infrastructure.Identity
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher; // Using object as TUser since we don't need a specific user type

        public PasswordHasher()
        {
            _passwordHasher = new PasswordHasher<object>();
        }
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
