using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Service
    {
        public readonly static string INSERT = " INSERT INTO TB_SERVICE (Description) VALUES (@Description); SELECT cast(scope_identity() as int) ";
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Descrição: {Description}";
        }
    }
}
