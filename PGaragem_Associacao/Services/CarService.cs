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
        public CarList RetrieveCarByColor(string color)
        {
            CarList carList = new CarList();
            try
            {
                carList = _repository.RetrieveCarByColor(color);
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
                carList = _repository.RetrieveCarByYear(year1, year2);
            }
            catch
            {
                throw;
            }
            return carList;
        }
    }
}
