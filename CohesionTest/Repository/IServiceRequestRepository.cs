using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
    }
}