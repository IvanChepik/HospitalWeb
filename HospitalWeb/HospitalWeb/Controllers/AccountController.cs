using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalDataAccess.Models.UserModels;
using HospitalWeb.ViewModels.Auth;
using HospitalWeb.ViewModels.Auth.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HospitalWeb.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]RegisterViewModel model)
        {

            if (!string.IsNullOrEmpty(model.FullName))
            {
                User user = new User { Email = model.Email, UserName = model.Email, FirstName = model.FullName.Substring(0, model.FullName.IndexOf(' ')), SecondName = model.FullName.Substring(model.FullName.IndexOf(' ')) };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok("135346341422");
                }
                else
                {
                    return BadRequest(new AuthResult<RegisterResponse>()
                                    .Fail(null, result.Errors.FirstOrDefault().Description));
                }
            }
            return BadRequest(new AuthResult<RegisterResponse>()
                            .Fail(null, GetModelStateError(ModelState)));
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        private string GetModelStateError(ModelStateDictionary state)
        {
            return state.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
        }
    }
}
