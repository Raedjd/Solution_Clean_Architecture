using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Contracts.Identity
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
