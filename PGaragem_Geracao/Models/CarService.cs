using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarService
    {
        public int Id { get; set; }
        public Car car { get; set; }
        public Service Service { get; set; }
        public bool Status { get; set; }
    }
}
