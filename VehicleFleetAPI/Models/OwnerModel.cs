using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleFleetAPI.Models
{
    public class OwnerModel
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name field is required.")]
        public string? Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "The CPF field is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF must be 11 digits.")]
        public string? CPF { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "The Address field is required.")]
        [StringLength(100, ErrorMessage = "Address should not exceed 100 characters.")]
        public string? Address { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? Phone { get; set; }
    }
}
