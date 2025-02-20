using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.XUnitTest.TestMock
{
    public class MockCarTest
    {
        // private readonly Mock<List<Car>> _mockService = new();
        CarMockServiceImpl _carMockServiceImpl = new();
        [Fact]
        public void Add_Car()
        {
            //Arrange
            var car = new Car() { Id = 2, Name = "Toyota", Color = "Red" };
            //act
            var addResult = _carMockServiceImpl.AddCar(car);
            var carList = _carMockServiceImpl.GetAll();
            //Assert
            addResult.Should().BeTrue();
            carList.Should().NotBeNull();
            carList.Should().HaveCount(2);
        }
        [Fact]
        public void Remove_Car()
        {
            //Arrange
           var car = new Car() { Id=2, Name="Toyota", Color="Red" };
           //act
           var removeResult = _carMockServiceImpl.RemoveCar(2);
           var carList = _carMockServiceImpl.GetAll();
           //Assert
            carList.Should().HaveCount(1);
        }

    }
}

