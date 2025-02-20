using AutoMapper;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.Feature.Users.Commands.AddUser;

namespace SolutionProject.XUnitTest.ApplicationTests.FeatureTests.Users.Commands
{
    public class AddUserCommandHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IRoleRepository> _mockRoleRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IValidator<AddUserCommand>> _validatorMock;
        private readonly AddUserCommandValidator _validator;

        public AddUserCommandHandlerTest() {
             _mockUserRepository = new Mock<IUserRepository>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockMapper = new Mock<IMapper>();  
            _validatorMock = new Mock<IValidator<AddUserCommand>>();
            _validator =new  AddUserCommandValidator(_mockUserRepository.Object, _mockRoleRepository.Object);

        }

        [Fact]
        public async Task Validator_Should_Have_Error_For_Invalid_Email()
        {
            // Arrange
            var invalidEmail = "invalid-email@gmail.com"; 
            var command = new AddUserCommand("John", "Doe", invalidEmail, "eeeeee", Guid.NewGuid());

            var expectedErrorMessage = "L'adresse e-mail n'est pas valide."; 

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email)
                  .WithErrorMessage(expectedErrorMessage);
        }

    }
}
