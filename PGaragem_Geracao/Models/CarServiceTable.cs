using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarServiceTable
    {
        public readonly static string INSERT = " INSERT INTO TB_CARSERVICE (LicensePlate, IdService, Status) VALUES (@LicensePlate, @Id, @Status); SELECT cast(scope_identity() as int) ";
        public readonly static string UPDATE = " UPDATE TB_CARSERVICE SET Status = @Status WHERE Id = @Id ";
        public int Id { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
        public bool Status { get; set; }
    }
}
