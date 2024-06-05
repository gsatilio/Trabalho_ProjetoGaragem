using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CarServiceTableController
    {
        private CarServiceTableService _service = new();
        public CarServiceTableController()
        {
            
        }
        public int InsertCarServiceTable(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                idService = _service.InsertCarServiceTable(carService);
            }
            catch
            {
                throw;
            }
            return idService;
        }

        public int ChangeStatusCarServiceTable(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                idService = _service.ChangeStatusCarServiceTable(carService);
            }
            catch
            {
                throw;
            }
            return idService;
        }

        public CarServiceTableList RetrieveCarServiceTable()
        {
            CarServiceTableList csList = new CarServiceTableList();
            try
            {
                csList = _service.RetrieveCarServiceTable();
            }
            catch
            {
                throw;
            }
            return csList;
        }
    }
}
