using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;

namespace TelegramWebAPI2.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class LogOutController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public LogOutController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Logout()
        {
            await _signInManager.SignOutAsync();
            return _signInManager.IsSignedIn(User);
        }
    }
}
