using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderPublish.Model;

namespace PublisherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessageController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Message message)
        {
            await _publishEndpoint.Publish(message);
            return Ok();
        }
    }
}
