using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CarServiceTableRepository
    {
        private string Conn { get; set; }
        public CarServiceTableRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["ConexaoSQL"].ConnectionString;
        }
        public int InsertCarService(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    idService = db.ExecuteScalar<int>(CarServiceTable.INSERT, new { carService.Car.LicensePlate, carService.Service.Id, carService.Status });
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return idService;
        }
        public int ChangeStatusCarServiceTable(CarServiceTable carService)
        {
            int idService = 0;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    idService = db.ExecuteScalar<int>(CarServiceTable.UPDATE, new
                    {
                        Id = carService.Id,
                        Status = carService.Status
                    });
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return idService;
        }
        public CarServiceTableList RetrieveCarServiceTable()
        {
            CarServiceTableList csList = new CarServiceTableList();
            csList.CarServiceTable = new List<CarServiceTable>();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query(" SELECT Id, LicensePlate, IdService, Status FROM TB_CARSERVICE ");
                    foreach (var item in tc)
                    {
                        csList.CarServiceTable.Add(new CarServiceTable
                        {
                            Id = item.Id,
                            Status = item.Status,
                            Car = RetrieveCar(item.LicensePlate),
                            Service = RetrieveService(item.IdService)
                        });

                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return csList;
        }

        public Car RetrieveCar(string licensePlate)
        {
            Car car = new Car();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query($" SELECT LicensePlate, Name, ModelYear, FabricationYear, Color FROM TB_CAR WHERE LicensePlate = '{licensePlate}' ");
                    foreach (var item in tc)
                    {
                        car = new Car
                        {
                            LicensePlate = item.LicensePlate,
                            Name = item.Name,
                            ModelYear = item.ModelYear,
                            FabricationYear = item.FabricationYear,
                            Color = item.Color
                        };
                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return car;
        }

        public Service RetrieveService(int Id)
        {
            Service serv = new Service();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query($" SELECT Id, Description FROM TB_SERVICE WHERE Id = {Id} ");
                    foreach (var item in tc)
                    {
                        serv = new Service
                        {
                            Id = item.Id,
                            Description = item.Description
                        };

                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return serv;
        }

        public CarServiceTableList RetrieveCarServiceTableStatus(bool status)
        {
            CarServiceTableList csList = new CarServiceTableList();
            csList.CarServiceTable = new List<CarServiceTable>();
            int auxstatus = 0;
            if (!status)
                auxstatus = 1;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query($" SELECT Id, LicensePlate, IdService, Status FROM TB_CARSERVICE WHERE Status = {auxstatus}");
                    foreach (var item in tc)
                    {
                        csList.CarServiceTable.Add(new CarServiceTable
                        {
                            Id = item.Id,
                            Status = item.Status,
                            Car = RetrieveCar(item.LicensePlate),
                            Service = RetrieveService(item.IdService)
                        });

                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return csList;
        }
    }
}
