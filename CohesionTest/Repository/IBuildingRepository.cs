using CohesionTest.Models.Entities;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public interface IBuildingRepository
    {
        Task<Building> GetByCodeAsync(string code);
    }
}