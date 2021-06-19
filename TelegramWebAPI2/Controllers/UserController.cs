using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ModelsLayer;
using DTO;

namespace TelegramWebAPI2.Controllers
{
    [Route("adminPanel/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class UserController : ControllerBase
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: adminPanel/<CategoryController>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {

            var result = _userManager.Users.ToList();
            var resultDTO = new List<UserDTO>();
            foreach (var user in result)
            {
                resultDTO.Add(user);
            }
            return resultDTO;
        }
    }
}
