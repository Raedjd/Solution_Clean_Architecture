using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionProject.XUnitTest.TestMock
{
    public interface ICarMockService
    {
        public bool AddCar(Car car);
        public bool RemoveCar(int? id);
        public List<Car> GetAll();
    }
}
