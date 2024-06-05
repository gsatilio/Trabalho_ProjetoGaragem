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
    public class CarRepository
    {
        private string Conn { get; set; }
        public CarRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["ConexaoSQL"].ConnectionString;
        }
        public CarList RetrieveCar()
        {
            CarList carList = new CarList();
            carList.Car = new List<Car>();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query(" SELECT LicensePlate, Name, ModelYear, FabricationYear, Color FROM TB_CAR ");
                    foreach (var item in tc)
                    {
                        carList.Car.Add(new Car
                        {
                            LicensePlate = item.LicensePlate,
                            Name = item.Name,
                            ModelYear = item.ModelYear,
                            FabricationYear = item.FabricationYear,
                            Color = item.Color
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
            return carList;
        }
    }
}
