using FluentValidation;
using SolutionProject.Application.Contracts.Persistence;

namespace SolutionProject.Application.Feature.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UpdateUserCommandValidator(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
     
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required.");

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Mail is required.")
                  .MustAsync(async (email, CancellationToken) =>
                  {
                      var mailExists = await _userRepository.ExistsByEmailAsync(email);
                      return !mailExists;
                  }).WithMessage("Email already exists");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId is required.")
             .MustAsync(async (roleId, CancellationToken) =>
             {
                 var roleExists = await _roleRepository.ExistsAsync(roleId);
                 return roleExists;
             }).WithMessage("Invalid Role ID. The specified Role does not exist");

        }
    }
}
