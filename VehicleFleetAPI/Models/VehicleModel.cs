
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleFleetAPI.Models
{
    public class VehicleModel
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Make of vehicle")]
        [Required(ErrorMessage = "Make is required.")]
        [StringLength(50, ErrorMessage = "Make cannot exceed 50 characters.")]
        public string? Make { get; set; }

        [Display(Name = "Model of vehicle")]
        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string? Model { get; set; }

        [Display(Name = "Year of manufacture")]
        [Required(ErrorMessage = "Manufacturing Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Manufacturing Year must be between 1900 and 2100.")]
        public int ManufacturingYear { get; set; }

        [Display(Name = "Vehicle license plate")]
        [Required(ErrorMessage = "License Plate is required.")]
        [StringLength(10, ErrorMessage = "License Plate cannot exceed 10 characters.")]
        public string? LicensePlate { get; set; }

        [Display(Name = "Vehicle color")]
        [Required(ErrorMessage = "Color is required.")]
        [StringLength(20, ErrorMessage = "Color cannot exceed 20 characters.")]
        public string? Color { get; set; }
    }
}
