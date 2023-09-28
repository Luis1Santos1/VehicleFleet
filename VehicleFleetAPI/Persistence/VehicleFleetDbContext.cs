using Microsoft.EntityFrameworkCore;
using VehicleFleetAPI.Models;

namespace VehicleFleetAPI.Persistence
{
    public class VehicleFleetDbContext : DbContext
    {
        public VehicleFleetDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<VehicleModel> Vehicles {  get; set; }
        public DbSet<OwnerModel> Owner { get; set; }
        public DbSet<VehicleInsuranceModel> VehicleInsurance { get; set; }
        public DbSet<MaintenanceHistoryModel> MaintenanceHistory { get; set; }

    }
}
