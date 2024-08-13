using AutoMapper;
using FluentValidation;
using MediatR;
using SolutionProject.Application.Common.Bases;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.Feature.Users.Commands.AddUser;
using SolutionProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.Application.Feature.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ResponseHandler, IRequestHandler<UpdateUserCommand, Response<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<UpdateUserCommand> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetByIdAsync(request.Id);
            if (userExists == null)
            {
                return NotFound<string>("User not found");
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequestValidation<string>(validationResult.Errors);
            }
              userExists.FirstName = request.FirstName;
              userExists.LastName = request.LastName;
              userExists.Email = request.Email;
               userExists.RoleId = request.RoleId;
             await _userRepository.UpdateAsync(userExists, cancellationToken);
            return Updated<string>("Updated Successfully");
        }
    }
}
