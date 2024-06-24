using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsumerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        [HttpGet("messages")]
        public ActionResult<List<string>> GetMessages()
        {
            var messages = MessageConsumer.GetMessages();
            return Ok(messages);
        }
    }
}
