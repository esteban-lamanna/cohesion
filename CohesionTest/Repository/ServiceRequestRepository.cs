using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly IList<ServiceRequest> _serviceRequests = new List<ServiceRequest>();

        public ServiceRequestRepository()
        {
            _serviceRequests.Add(new ServiceRequest()
            {

            });
        }


        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            //suposing there is a delay looking for data
            return await Task.Run(() =>
            {
                return _serviceRequests;
            });
        }
    }
}