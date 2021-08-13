using CohesionTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CohesionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAsync()
        {
            var states = _statusService.GetAll();

            if (!states.Any())
                return NoContent();

            return Ok(states);
        }
    }
}