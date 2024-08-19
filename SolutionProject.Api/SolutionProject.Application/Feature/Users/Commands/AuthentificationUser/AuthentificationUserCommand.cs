using MediatR;
using SolutionProject.Application.DataTransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Feature.Users.Commands.AuthentificationUser
{
    public class AuthentificationUserCommand : IRequest<AuthenticationResultDto>
    {
        public AuthentificationUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
