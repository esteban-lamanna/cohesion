using CohesionTest.Models.Responses;
using CohesionTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            if (!users.Any())
                return NoContent();

            return Ok(users.Select(a => (UserResponse)a));
        }
    }
}