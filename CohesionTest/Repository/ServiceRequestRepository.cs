using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private static readonly IList<ServiceRequest> _serviceRequests = new List<ServiceRequest>();

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            //suposing there is always a long delay accessing data
            return await Task.Run(() =>
            {
                return _serviceRequests;
            });
        }

        public async Task InsertAsync(ServiceRequest serviceRequest)
        {
            await Task.Run(() =>
            {
                _serviceRequests.Add(serviceRequest);
            });
        }
    }
}