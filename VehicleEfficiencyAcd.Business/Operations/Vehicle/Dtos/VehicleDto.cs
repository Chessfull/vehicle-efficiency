using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ImagePath { get; set; }
    }
}
