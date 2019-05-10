using System;
using Microsoft.AspNetCore.Mvc;

namespace boilerplate.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var version = typeof(RuntimeEnvironment).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            return Ok($"{'Verson': '{version}', 'Name': 'boilerplate'}");
        }
    }
}