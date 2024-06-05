using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CarService
    {
        private CarRepository _repository = new();
        public CarList RetrieveCar()
        {
            CarList carList = new CarList();
            try
            {
                carList = _repository.RetrieveCar();
            }
            catch
            {
                throw;
            }
            return carList;
        }
    }
}
