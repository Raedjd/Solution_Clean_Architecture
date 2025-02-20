using AutoMapper;
using FluentAssertions;
using Moq;
using SolutionProject.Application.Contracts.Persistence;
using SolutionProject.Application.DataTransfertObject;
using SolutionProject.Application.Feature.Users.Queries.GetListUsers;
using SolutionProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SolutionProject.XUnitTest.ApplicationTests.FeatureTests.Users.Queries
{
    public class GetUsersListQueryHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetUsersListQueryHandler _handler;

        public GetUsersListQueryHandlerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetUsersListQueryHandler(_mockUserRepository.Object, _mockMapper.Object);

        }
        [Fact]
        public async Task GetUsersListDtoTest()
        {

            //Arrang
            var request = new GetUsersListQuery();
            var users = new List<User>(); // Mocked list of users
            var mappedUsers = new List<UserDto>(); // Mocked mapped list of UserDto

            _mockUserRepository.Setup(repo => repo.ListAsync(default)).ReturnsAsync(users);
            _mockMapper.Setup(mapper => mapper.Map<List<UserDto>>(users)).Returns(mappedUsers);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(mappedUsers);
        }
    }
}
