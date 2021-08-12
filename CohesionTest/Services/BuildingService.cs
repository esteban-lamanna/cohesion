using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _BuildingRepository;

        public BuildingService(IBuildingRepository BuildingRepository)
        {
            _BuildingRepository = BuildingRepository;
        }

        public async Task<Building> GetByCodeAsync(string code)
        {
            return await _BuildingRepository.GetByCodeAsync(code);
        }
    }
}