namespace VehicleEfficiencyAcd.Presentation.Models.Vehicle
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ImagePath { get; set; }

    }
}
