using CohesionTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CohesionTest.Models.Requests
{
    public class UpdateServiceRequest : IValidatableObject
    {
        [Required]
        public int NewState { get; set; }

        [Required]
        public Guid IdUser { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var list = new List<ValidationResult>();

            if (!Enum.IsDefined(typeof(ServiceRequest.PossibleStates), NewState))
            {
                list.Add(new ValidationResult("NewState is invalid"));
            }

            return list;
        }
    }
}