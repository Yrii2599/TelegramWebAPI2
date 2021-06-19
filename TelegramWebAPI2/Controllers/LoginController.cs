using System.Linq;
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
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid && !_signInManager.IsSignedIn(User))
            {
                var user = _userManager.Users.ToList().FirstOrDefault(u => u.Email == model.Name_Email && _userManager.CheckPasswordAsync(u, model.Password).Result);
                if (user != null)
                {
                    model.Name_Email = user.UserName;
                }
                var result = await _signInManager.PasswordSignInAsync(model.Name_Email, model.Password, model.RememberMe, false);

                return result.Succeeded;

            }
            return false;
        }
    }
}
