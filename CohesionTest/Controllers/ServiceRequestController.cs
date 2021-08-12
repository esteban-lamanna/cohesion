using CohesionTest.Models.Responses;
using CohesionTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : Controller
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }


        [HttpGet("")]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var servicesRequests = await _serviceRequestService.GetAllAsync();

            return Ok(servicesRequests.Select(a => (ServiceRequestResponse)a));
        }
    }
}
