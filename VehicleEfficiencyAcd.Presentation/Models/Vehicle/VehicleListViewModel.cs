namespace VehicleEfficiencyAcd.Presentation.Models.Vehicle
{
    public class VehicleListViewModel
    {
        public List<VehicleViewModel> Vehicles { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
