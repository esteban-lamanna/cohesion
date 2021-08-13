using System;
using System.ComponentModel.DataAnnotations;

namespace CohesionTest.Models.Requests
{
    public class CreationOfServiceRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public string BuildingCode { get; set; }

        [Required]
        public Guid IdUser { get; set; }
    }
}