using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories
{
    public class ServiceRepository
    {
        private string Conn { get; set; }
        public ServiceRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["ConexaoSQL"].ConnectionString;
        }

        public int InsertService(Service service)
        {
            int idService = 0;
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    idService = db.ExecuteScalar<int>(Service.INSERT, service);
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
        public ServiceList RetrieveService()
        {
            ServiceList servList = new ServiceList();
            servList.Service = new List<Service>();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var tc = db.Query(" SELECT Id, Description FROM TB_SERVICE ");
                    foreach (var item in tc)
                    {
                        servList.Service.Add(new Service
                        {
                            Id = item.Id,
                            Description = item.Description
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
            return servList;
        }
    }
}
