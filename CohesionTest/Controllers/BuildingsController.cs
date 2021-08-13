using CohesionTest.Models.Responses;
using CohesionTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : Controller
    {
        private readonly IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var buildings = await _buildingService.GetAllAsync();

            if (!buildings.Any())
                return NoContent();

            return Ok(buildings.Select(a => (BuildingResponse)a));
        }
    }
}