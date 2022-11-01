using Microsoft.AspNetCore.Mvc;
using WebApplication1.Queues;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController:ControllerBase
    {
        private readonly IBackgroundTask<string> queue;

        public TestController(IBackgroundTask<string> queue)
        {
            this.queue = queue;
        }
        [HttpPost]
        public async Task<IActionResult> AddQueue(string[] names)
        {
            foreach(var name in names)
            {
               await queue.AddQueue(name);
            }
            return Ok();
        }
    }
}
