using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos
{
    public class PerformanceInsightDto
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public List<string> Weeks { get; set; } // Weeks like "w1", "w2", etc.
        public List<int> TotalHours { get; set; } // Total hours for each week
        public List<int> WorkHours { get; set; }  // Work hours for each week

    }
}
