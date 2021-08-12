using CohesionTest.Models.Entities;

namespace CohesionTest.Models.Responses
{
    public class ServiceRequestResponse
    {
        public static explicit operator ServiceRequestResponse(ServiceRequest v)
        {
            if (v == null)
                return null;

            return new ServiceRequestResponse()
            {

            };
        }
    }
}