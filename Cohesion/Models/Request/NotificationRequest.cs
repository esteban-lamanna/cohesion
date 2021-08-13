using CohesionTest.Models.Entities;
using System;

namespace CohesionTest.Models.Request
{
    public class NotificationRequest
    {
        public Guid IdUser { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public static explicit operator NotificationRequest(ServiceRequest v)
        {
            if (v == null)
                return null;

            return new NotificationRequest()
            {
                IdUser = v.User.Id
            };
        }
    }
}