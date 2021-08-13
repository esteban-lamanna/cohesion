using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface IBuildingService
    {
        Task<Building> GetByCodeAsync(string code);
        Task<IEnumerable<Building>> GetAllAsync();
    }
}