using Microsoft.AspNetCore.Identity;
using SolutionProject.Application.Contracts.Identity;


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
    }
}
