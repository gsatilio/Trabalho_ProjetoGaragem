using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CarController
    {
        private CarService _service = new();
        public CarList RetrieveCar()
        {
            CarList carList = new CarList();
            try
            {
                carList = _service.RetrieveCar();
            }
            catch
            {
                throw;
            }
            return carList;
        }
    }
}
