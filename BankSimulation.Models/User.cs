using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BankSimulation.Models
{

    public class MinimumAgeAttribute : ValidationAttribute { 
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validation) {
            if (value != null) { 
                int age = (int)value;

                if (age < _minimumAge)
                {
                    return new ValidationResult($"Age should be atleast {_minimumAge} years.");
                }
            }
            return ValidationResult.Success;
        }

    }
    public class User:IdentityUser
    {
        [Required]
        [DisplayName("Account Holder Name")]
        public string Name{ get; set; }
        [MinimumAge(16, ErrorMessage ="Age should be atleast 16 years.")]
        public int Age { get; set; }
        public string? District{ get; set; }
        public string? Address { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
