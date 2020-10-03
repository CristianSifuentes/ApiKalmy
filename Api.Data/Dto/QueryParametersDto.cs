using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Api.Data.Dto
{
   public class QueryParametersDto
    {
        [Required]
        [StringRange(AllowableValues = new[] { "Type", "Brand", "Model" }, ErrorMessage = "Parameter must be either 'Type', 'Brand' or 'Model'.")]
        public string Parameter1 { get; set; }

        [StringRange(AllowableValues = new[] { "Type", "Brand", "Model", null, "" }, ErrorMessage = "Parameter must be either 'Type', 'Brand' or 'Model'.")]
        public string Parameter2 { get; set; }
    }

    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }


    
}
