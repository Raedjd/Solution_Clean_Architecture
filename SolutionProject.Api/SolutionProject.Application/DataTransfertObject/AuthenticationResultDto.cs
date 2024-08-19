using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.DataTransfertObject
{
    public class AuthenticationResultDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; } = null!;
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; } = null!;
    }
}
