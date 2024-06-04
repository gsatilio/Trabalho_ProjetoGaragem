using Models;
using Newtonsoft.Json;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository = new();
        
        public void InsertFileOnSQL(string jsonString)
        {
            var json = JsonConvert.DeserializeObject<CarList>(jsonString);
            _carRepository.Delete();

            _carRepository.InsertBatch(json);
        }
    }
}
