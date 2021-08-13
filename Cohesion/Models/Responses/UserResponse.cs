using CohesionTest.Models.Entities;
using System;

namespace CohesionTest.Models.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator UserResponse(User v)
        {
            if (v == null)
                return null;
            return new UserResponse()
            {
                Id = v.Id,
                Name = v.Name
            };
        }
    }
}