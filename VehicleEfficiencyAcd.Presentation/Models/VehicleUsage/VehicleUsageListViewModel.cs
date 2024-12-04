namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class VehicleUsageListViewModel
    {
        public List<VehicleUsageViewModel> VehicleUsages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
