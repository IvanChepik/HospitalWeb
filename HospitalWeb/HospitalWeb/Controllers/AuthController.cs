using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Extensions.Identity;
using HospitalWeb.Models.Auth;
using HospitalWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly AuthenticationService<User> _authService;

        public AuthController(AuthenticationService<User> authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDto)
        {
            var result = await _authService.Login(loginDto);

            if (result.Succeeded)
            {
                return Ok(new { token = result.Data });
            }
            if (result.IsModelValid)
            {
                return Unauthorized();
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        [Route("reset-pass")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDto)
        {
            var currentUserId = User.GetUserId();

            var result = await _authService.ChangePassword(changePasswordDto, currentUserId);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDto)
        {
            var result = await _authService.SignUp(signUpDto);

            if (result.Succeeded)
                return Ok(new { token = result.Data });

            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("request-pass")]
        public async Task<IActionResult> RequestPassword(RequestPasswordDTO requestPasswordDto)
        {
            var result = await _authService.RequestPassword(requestPasswordDto);

            if (result.Succeeded)
                return Ok(new { result.Data, Description = "Reset Token should be sent via Email. Token in response - just for testing purpose." });

            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("restore-pass")]
        public async Task<IActionResult> RestorePassword(RestorePasswordDTO restorePasswordDto)
        {
            var result = await _authService.RestorePassword(restorePasswordDto);

            if (result.Succeeded)
                return Ok(new { token = result.Data });

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        [Route("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var result = await _authService.RefreshToken(refreshTokenDTO);

            if (result.Succeeded)
                return Ok(new { token = result.Data });

            return BadRequest();
        }
    }
}
