using CohesionTest.Models.Entities;
using CohesionTest.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task CreateAsync(ServiceRequest serviceRequest);
        Task<ServiceRequest> GetByIdAsync(Guid id);
        Task UpdateAsync(ServiceRequest serviceRequest, UpdateServiceRequest updateRequest);
        Task DeleteAsync(ServiceRequest serviceRequest);
    }
}