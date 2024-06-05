using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories
{
    public class CarRepository
    {
        private string Conn { get; set; }
        public CarRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["ConexaoSQL"].ConnectionString;
        }
        public bool InsertBatch(CarList carList)
        {
            var result = false;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    foreach (var item in carList.Car)
                    {
                        db.Execute("INSERT INTO TB_CAR (LicensePlate, Name, ModelYear, FabricationYear, Color) VALUES " +
                                   "(@LicensePlate, @Name, @ModelYear, @FabricationYear, @Color)", item);
                    }
                    db.Close();
                    result = true;
                }
                result = true;
            }
            catch
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool Delete()
        {
            var result = false;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    db.Execute(" DELETE FROM TB_CARSERVICE; DELETE FROM TB_CAR ");
                    db.Close();
                    result = true;
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            return result;
        }
    }
}
