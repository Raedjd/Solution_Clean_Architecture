using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.XUnitTest.TestMock
{
    public class CarMockServiceImpl : ICarMockService
    {
        public List<Car> carList = new()
        {
            new Car{Id = 1, Name="Golf7", Color="White"}
        };

        public bool AddCar(Car car)
        {
            carList.Add(car);
            return true;
        }

        public List<Car> GetAll()
        {
            return carList;
        }

        public bool RemoveCar(int? id)
        {
            if (id == null) return false;
            var car = carList.Find(x => x.Id == id);
            if (car == null) return false;
            return carList.Remove(car);
        }
    }
}
