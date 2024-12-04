using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos
{
    public class AddVehicleDto
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string ImagePath { get; set; }
    }
}
