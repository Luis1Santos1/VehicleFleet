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
        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<VehicleInsuranceModel> VehiclesInsurances { get; set; }
        public DbSet<MaintenanceHistoryModel> MaintenancesHistorys { get; set; }

    }
}
