using System;
using Microsoft.AspNetCore.Mvc;

namespace boilerplate.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("{'value1': 1, 'value2': 2}");
        }
    }
}