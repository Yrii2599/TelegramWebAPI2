using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;
using ViewModelsLayer.ViewDataModels;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramWebAPI2.Controllers
{
    [Route("[controller]")]
    [EnableCors("Cors")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public MessageController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET: api/<MessageController>
        [HttpGet]
        public ActionResult<List<MessageDTO>> Get()
        {
            var logicManager = new MessagesLogic(User.Identity, _userManager);
            return logicManager.ReadAllOwnMessages().ToList();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public Message Get(int id)
        {
            var logicManager = new MessagesLogic(User.Identity, _userManager);
            return logicManager.ReadMessage(id);
        }

        // POST api/<MessageController>
        [HttpPost]
        public bool Post([FromBody] CreateMessageViewModel value)
        {
            var logicManager = new MessagesLogic(User.Identity, _userManager);
            return logicManager.CreateMessage(value.Text, value.Receivers);
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] CreateMessageViewModel value)
        {
            var logicManager = new MessagesLogic(User.Identity, _userManager);
            return logicManager.EditMessage(id, value.Text, value.Receivers);
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var logicManager = new MessagesLogic(User.Identity, _userManager);
            return logicManager.RemoveMessage(id);
        }
    }
}
