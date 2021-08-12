using CohesionTest.Models.Entities;
using CohesionTest.Models.Requests;
using CohesionTest.Models.Responses;
using CohesionTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : Controller
    {
        private readonly IServiceRequestService _serviceRequestService;
        private readonly IUserService _userService;
        private readonly IBuildingService _buildingService;
        private readonly ILogger<ServiceRequestController> _logger;


        public ServiceRequestController(IServiceRequestService serviceRequestService,
                                        ILogger<ServiceRequestController> logger,
                                        IBuildingService buildingService,
                                        IUserService userService
                                        )
        {
            _serviceRequestService = serviceRequestService;
            _logger = logger;
            _userService = userService;
            _buildingService = buildingService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var servicesRequests = await _serviceRequestService.GetAllAsync();

            if (!servicesRequests.Any())
                return NoContent();

            return Ok(servicesRequests.Select(a => (ServiceRequestResponse)a));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreationOfServiceRequest creationOfServiceRequest)
        {
            var validRequest = await ValidateRequestAsync(creationOfServiceRequest);

            if (!validRequest.Item1)
            {
                _logger.LogError(validRequest.Item2);
                return BadRequest(validRequest.Item2);
            }

            var serviceRequest = await MapToEntityAsync(creationOfServiceRequest);

            await _serviceRequestService.CreateAsync(serviceRequest);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateServiceRequest updateServiceRequest)
        {
            var serviceRequest = await _serviceRequestService.GetByIdAsync(id);

            if (serviceRequest == null)
            {
                _logger.LogError("invalid service request ID");
                return BadRequest("invalid service request ID");
            }

            var validRequest = await ValidateUpdateRequestAsync(updateServiceRequest);

            if (!validRequest.Item1)
            {
                _logger.LogError(validRequest.Item2);
                return BadRequest(validRequest.Item2);
            }

            await _serviceRequestService.UpdateAsync(serviceRequest, updateServiceRequest);

            return Ok();
        }

        private async Task<(bool, string)> ValidateUpdateRequestAsync(UpdateServiceRequest updateServiceRequest)
        {
            var user = await _userService.GetByIdAsync(updateServiceRequest.IdUser);

            if (user == null)
                return (false, "Invalid User");

            return (true, null);
        }

        private async Task<(bool, string)> ValidateRequestAsync(CreationOfServiceRequest creationOfServiceRequest)
        {
            var user = await _userService.GetByIdAsync(creationOfServiceRequest.IdUser);

            if (user == null)
                return (false, "Invalid User");

            var building = await _buildingService.GetByCodeAsync(creationOfServiceRequest.BuildingCode);

            if (building == null)
                return (false, "Invalid building code");

            return (true, null);
        }

        private async Task<ServiceRequest> MapToEntityAsync(CreationOfServiceRequest creationOfServiceRequest)
        {
            var entity = ServiceRequest.CreateInstance();
            entity.Description = creationOfServiceRequest.Description;
            entity.Building = await _buildingService.GetByCodeAsync(creationOfServiceRequest.BuildingCode);

            var user = await _userService.GetByIdAsync(creationOfServiceRequest.IdUser);
            entity.SetStatus(ServiceRequest.PossibleStates.Created, user);

            return entity;
        }
    }
}