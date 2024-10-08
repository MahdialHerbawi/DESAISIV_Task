using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
namespace DESAISIV.customValidtion
{



    public class ValidPublicationYearAttribute : ValidationAttribute
    {
        private readonly int _minYear;

        public ValidPublicationYearAttribute(int minYear)
        {
            _minYear = minYear;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;

                if (year < _minYear || year > currentYear)
                {
                    return new ValidationResult($"Publication year must be between {_minYear} and {currentYear}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

