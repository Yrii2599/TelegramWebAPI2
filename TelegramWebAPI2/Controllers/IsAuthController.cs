using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;

namespace TelegramWebAPI2.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class IsAuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public IsAuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public bool Get()
        {
            return _signInManager.IsSignedIn(User);
        }
    }
}
