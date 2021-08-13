using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository BuildingRepository)
        {
            _buildingRepository = BuildingRepository;
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _buildingRepository.GetAllAsync();
        }

        public async Task<Building> GetByCodeAsync(string code)
        {
            return await _buildingRepository.GetByCodeAsync(code);
        }
    }
}