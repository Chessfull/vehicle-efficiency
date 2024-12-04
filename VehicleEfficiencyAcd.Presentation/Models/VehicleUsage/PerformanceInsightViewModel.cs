namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class PerformanceInsightViewModel
    {
        public List<PerformanceInsightCardViewModel> VehiclePerformanceData { get; set; }
    }
    public class PerformanceInsightCardViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleImagePath { get; set; }
        public List<WeeklyPerformanceData> WeeklyData { get; set; }
    }

    public class WeeklyPerformanceData
    {
        public string Week { get; set; }
        public double TotalHours { get; set; } // Total hours (constant 168)
        public double ActiveHours { get; set; } // Active hours for the week
        public double MaintenanceHours { get; set; }
        public double Ratio { get; set; } // Active hours ratio
    }
}
