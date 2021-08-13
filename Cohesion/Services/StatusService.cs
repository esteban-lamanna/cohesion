using CohesionTest.Models.Entities;
using CohesionTest.Models.Responses;
using System;
using System.Collections.Generic;

namespace CohesionTest.Services
{
    public class StatusService : IStatusService
    {
        public IEnumerable<StatusResponse> GetAll()
        {
            var list = new List<StatusResponse>();

            var values = Enum.GetValues(typeof(ServiceRequest.PossibleStates));

            foreach (var value in values)
            {
                list.Add(new StatusResponse()
                {
                    Description = value.ToString(),
                    Id = (int)(ServiceRequest.PossibleStates)value
                });
            }

            return list;
        }
    }
}