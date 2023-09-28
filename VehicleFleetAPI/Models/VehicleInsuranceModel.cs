using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleFleetAPI.Models
{
    public class VehicleInsuranceModel
    {
        [Display(Name = "Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Insurance Company")]
        [Required(ErrorMessage = "The Insurance Company field is required.")]
        public string? InsuranceCompany { get; set; }

        [Display(Name = "Policy Number")]
        [Required(ErrorMessage = "The Policy Number field is required.")]
        public string? PolicyNumber { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The Start Date field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The End Date field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateGreaterThan("StartDate", ErrorMessage = "The End Date must be greater than the Start Date.")]
        public DateTime EndDate { get; set; }
    }

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public DateGreaterThanAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;
            var propertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (propertyInfo == null)
            {
                return new ValidationResult($"Unknown property {_startDatePropertyName}");
            }

            var startDate = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (endDate <= startDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
