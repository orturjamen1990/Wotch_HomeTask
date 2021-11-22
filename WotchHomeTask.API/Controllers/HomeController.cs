using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WotchHomeTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BackgroundRequestQueue _queue;

        public HomeController(ILogger<HomeController> logger, BackgroundRequestQueue queue)
        {
            _logger = logger;
            this._queue = queue;
        }

        [HttpPost]
        public async Task<ActionResult> SendData(object data)
        {
            _queue.QueueBackgroundWorkItem(data);
            await Task.CompletedTask;
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetMoreData()
        {
            await Task.CompletedTask;
            return Ok(5);
        }

    }
}
