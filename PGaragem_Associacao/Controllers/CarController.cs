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
        public CarList RetrieveCarByColor(string color)
        {
            CarList carList = new CarList();
            try
            {
                carList = _service.RetrieveCarByColor(color);
            }
            catch
            {
                throw;
            }
            return carList;
        }

        public CarList RetrieveCarByYear(int year1, int year2)
        {
            CarList carList = new CarList();
            try
            {
                carList = _service.RetrieveCarByYear(year1, year2);
            }
            catch
            {
                throw;
            }
            return carList;
        }

    }
}
