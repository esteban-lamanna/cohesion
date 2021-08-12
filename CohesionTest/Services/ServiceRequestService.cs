using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;

        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
        }

        public async Task CreateAsync(ServiceRequest serviceRequest)
        {
            await _serviceRequestRepository.InsertAsync(serviceRequest);
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _serviceRequestRepository.GetAllAsync();
        }
    }
}