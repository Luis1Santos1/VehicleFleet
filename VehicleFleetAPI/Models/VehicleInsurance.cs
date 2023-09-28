namespace VehicleFleetAPI.Models
{
    public class VehicleInsurance
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
