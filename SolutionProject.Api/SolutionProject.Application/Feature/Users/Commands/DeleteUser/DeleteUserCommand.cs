using MediatR;
using SolutionProject.Application.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Feature.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }
}
