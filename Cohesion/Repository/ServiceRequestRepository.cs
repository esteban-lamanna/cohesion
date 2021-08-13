using CohesionTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ServiceRequest> GetByIdAsync(Guid id)
        {
            //suposing there is always a long delay accessing data
            return await Task.Run(() =>
            {
                return _serviceRequests.FirstOrDefault(a => a.Id == id);
            });
        }

        public async Task InsertAsync(ServiceRequest serviceRequest)
        {
            //suposing there is always a long delay accessing data
            await Task.Run(() =>
            {
                _serviceRequests.Add(serviceRequest);
            });
        }

        public async Task UpdateAsync(Guid id, ServiceRequest serviceRequest)
        {
            //suposing there is always a long delay accessing data
            await Task.Run(() =>
            {
                var current = _serviceRequests.FirstOrDefault(a => a.Id == id);

                _serviceRequests.Remove(current);

                _serviceRequests.Add(serviceRequest);
            });
        }
    }
}