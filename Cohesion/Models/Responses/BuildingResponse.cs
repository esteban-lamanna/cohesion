using CohesionTest.Models.Entities;
using System;

namespace CohesionTest.Models.Responses
{
    public class BuildingResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public static explicit operator BuildingResponse(Building v)
        {
            if (v == null)
                return null;

            return new BuildingResponse()
            {
                Name = v.Name,
                Id = v.Id,
                Code = v.Code
            };
        }
    }
}