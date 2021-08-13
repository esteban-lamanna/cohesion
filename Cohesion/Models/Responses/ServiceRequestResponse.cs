using CohesionTest.Models.Entities;
using System;
using System.Linq;

namespace CohesionTest.Models.Responses
{
    public class ServiceRequestResponse
    {
        public Guid Id { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public static explicit operator ServiceRequestResponse(ServiceRequest v)
        {
            if (v == null)
                return null;

            return new ServiceRequestResponse()
            {
                BuildingCode = v.Building.Code,
                LastModifiedDate = v.History?.ToList().LastOrDefault()?.Date,
                CreatedDate = v.History.ToList().First().Date,
                CreatedBy = v.History.ToList().First().User.Name,
                Description = v.Description,
                Id = v.Id,
                CurrentStatus = v.CurrentState.ToString()
            };
        }
    }
}