using SolutionProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}
