namespace VehicleFleetAPI.Models
{
    public class MaintenanceHistoryModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string ServiceType { get; set; }
        public decimal Cost { get; set; }
    }
}
