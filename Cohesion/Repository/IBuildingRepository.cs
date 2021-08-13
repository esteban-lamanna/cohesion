using CohesionTest.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IBuildingRepository
    {
        Task<Building> GetByCodeAsync(string code);
        Task<IEnumerable<Building>> GetAllAsync();
    }
}