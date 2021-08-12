using CohesionTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task InsertAsync(ServiceRequest serviceRequest);
        Task<ServiceRequest> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, ServiceRequest serviceRequest);
    }
}