using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos
{
    public class VehicleUsageListDto
    {
        public List<VehicleUsageDto> VehicleUsages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
