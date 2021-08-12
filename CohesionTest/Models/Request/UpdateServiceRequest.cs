using CohesionTest.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CohesionTest.Models.Requests
{
    public class UpdateServiceRequest
    {
        [Required]
        public ServiceRequest.PossibleStates NewState { get; set; }

        [Required]
        public Guid IdUser { get; set; }
    }
}