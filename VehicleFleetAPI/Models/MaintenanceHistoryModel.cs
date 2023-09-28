using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleFleetAPI.Models
{
    public class MaintenanceHistoryModel
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Vehicle Id")]
        [Required(ErrorMessage = "The Vehicle Id field is required.")]
        public int VehicleId { get; set; }

        [Display(Name = "Maintenance Date")]
        [Required(ErrorMessage = "The Maintenance Date field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MaintenanceDate { get; set; }

        [Display(Name = "Service Type")]
        [Required(ErrorMessage = "The Service Type field is required.")]
        [StringLength(50, ErrorMessage = "The Service Type field cannot exceed 50 characters.")]
        public string? ServiceType { get; set; }

        [Display(Name = "Service Cost")]
        [Required(ErrorMessage = "The Service Cost field is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Cost { get; set; }
    }
}