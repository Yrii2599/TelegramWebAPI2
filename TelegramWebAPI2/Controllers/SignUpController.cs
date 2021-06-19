using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;
using ViewModelsLayer.ViewDataModels;

namespace TelegramWebAPI2.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class SignUpController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager; 
        private readonly UserManager<User> _userManager;

        public SignUpController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid && !_signInManager.IsSignedIn(User))
            {
                User user = new User {Email = model.Email, UserName = model.Name};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return "True";
                }
                else
                {
                    var errors = "";
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description;
                        return errors;
                    }
                }
            }

            return "False";
        }
    }
}
