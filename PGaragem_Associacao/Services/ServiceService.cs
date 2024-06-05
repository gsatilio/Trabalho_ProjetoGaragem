using Models;
using Repositories;

namespace Services
{
    public class ServiceService
    {
        private ServiceRepository _repository = new();

        public int InsertService(Service service)
        {
            int idService = 0;
            try
            {
                idService =  _repository.InsertService(service);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return idService;
        }

        public ServiceList RetrieveService()
        {
            ServiceList servList = new ServiceList();
            try
            {
                servList = _repository.RetrieveService();
            }
            catch
            {
                throw;
            }
            return servList;
        }
    }
}
