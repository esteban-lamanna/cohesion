using CohesionTest.Models.Entities;
using CohesionTest.Repository.TestData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly IList<Building> _buildings = new List<Building>();

        public BuildingRepository()
        {
            _buildings.Add(MockData.EmpireState);
        }

        public async Task<Building> GetByCodeAsync(string code)
        {
            //suposing there is always a long delay accessing data
            return await Task.Run(() =>
            {
                return _buildings.FirstOrDefault(a => a.Code.ToLower() == code.ToLower());
            });
        }
    }
}