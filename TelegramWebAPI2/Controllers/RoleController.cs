using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TelegramWebAPI2.Controllers
{
    [Route("adminPanel/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: adminPanel/<CategoryController>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<IdentityRole>> Get()
        {
            var result = _roleManager.Roles.ToList();
            return result;
        }
    }
}
