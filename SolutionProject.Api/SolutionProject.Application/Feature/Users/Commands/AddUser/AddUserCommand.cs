using MediatR;
using SolutionProject.Application.Common.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Feature.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
