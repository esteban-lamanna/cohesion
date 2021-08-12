using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task CreateAsync(ServiceRequest serviceRequest);
    }
}