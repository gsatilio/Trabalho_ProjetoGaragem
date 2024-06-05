using Microsoft.Data.SqlClient;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
    public class CarServiceTableService
    {
        CarServiceTableRepository _repository = new();
        public int InsertCarServiceTable(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                idService = _repository.InsertCarService(carService);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return idService;
        }
        public int ChangeStatusCarServiceTable(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                idService = _repository.ChangeStatusCarServiceTable(carService);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return idService;
        }
        public CarServiceTableList RetrieveCarServiceTable()
        {
            CarServiceTableList csList = new CarServiceTableList();
            try
            {
                csList = _repository.RetrieveCarServiceTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return csList;
        }

        public CarServiceTableList RetrieveCarServiceTableStatus(bool status)
        {
            CarServiceTableList csList = new CarServiceTableList();
            try
            {
                csList = _repository.RetrieveCarServiceTableStatus(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return csList;
        }
    }
}
