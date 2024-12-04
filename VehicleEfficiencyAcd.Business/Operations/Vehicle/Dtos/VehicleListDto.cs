using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos
{
    public class VehicleListDto
    {
        public List<VehicleDto> Vehicles { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
