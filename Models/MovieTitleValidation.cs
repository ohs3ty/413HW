using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Validates the Independence Day controversy between Professor Hilton and his brother
namespace HW3_413.Models
{
    public class MovieTitleValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string movieControversy = "Independence Day";

            if (Convert.ToString(value) == movieControversy)
            {
                ErrorMessage = "Sorry, you can't add this movie. It is NOT the \"Most American Movie Made.\"";
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
