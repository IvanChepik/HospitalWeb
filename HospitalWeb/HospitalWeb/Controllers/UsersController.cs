using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Extensions.Identity;
using HospitalWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalWeb.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        protected readonly UserService<User> _userService;
        protected readonly JwtManager _jwtManager;

        public UsersController(UserService<User> userService, JwtManager jwtManager)
        {
            _userService = userService;
            _jwtManager = jwtManager;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrent()
        {
            var currentUserId = User.GetUserId();
            if (currentUserId != null)
            {
                var user = await _userService.GetById(currentUserId);
                return Ok(user);
            }

            return Unauthorized();
        }
    }
}
