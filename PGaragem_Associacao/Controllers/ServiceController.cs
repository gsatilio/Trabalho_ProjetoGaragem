using Models;
using Services;

namespace Controllers
{
    public class ServiceController
    {
        private ServiceService _service = new();

        public ServiceController()
        {

        }
        public int InsertService(Service service)
        {
            int idService = 0;
            try
            {
                idService = _service.InsertService(service);
            }
            catch
            {
                throw;
            }
            return idService;
        }
        public ServiceList RetrieveService()
        {
            ServiceList servList = new ServiceList();
            try
            {
                servList = _service.RetrieveService();
            }
            catch
            {
                throw;
            }
            return servList;
        }
    }
}
