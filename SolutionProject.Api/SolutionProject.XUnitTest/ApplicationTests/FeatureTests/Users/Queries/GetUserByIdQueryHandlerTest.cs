using AutoMapper;
using FluentAssertions;
using Moq;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.DataTransfertObject;
using SolutionProject.Application.Feature.Users.Queries.GetUserById;
using SolutionProject.Domain.Entities;
namespace SolutionProject.XUnitTest.ApplicationTests.FeatureTests.Users.Queries
{
    public class GetUserByIdQueryHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetUserByIdQueryHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsyncWithCorrectId()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var request = new GetUserByIdQuery { Id = userId };
            var mappedUser = new UserDto(); // Mocked mapped of UserDto
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId,default)).ReturnsAsync((User)null);
            _mockMapper.Setup(mapper => mapper.Map<UserDto>((User)null)).Returns(mappedUser);

            // Act
            var result = await _handler.Handle(request, default);

            // Assert
            result.Succeeded.Should().BeFalse();
 
        }
    }
}
