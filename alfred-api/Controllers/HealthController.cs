using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("ready")]
        public ActionResult Readiness()
        {
            // Testing all setup cached objects are loaded
            return new OkResult();
        }

        [HttpGet("live")]
        public ActionResult Liveness()
        {
            // Testing 
            return new OkResult();
        }
    }
}