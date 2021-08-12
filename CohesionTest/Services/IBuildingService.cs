using CohesionTest.Models.Entities;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface IBuildingService
    {
        Task<Building> GetByCodeAsync(string code);
    }
}