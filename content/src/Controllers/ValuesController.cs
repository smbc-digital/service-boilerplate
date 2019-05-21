using System;
using Microsoft.AspNetCore.Mvc;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using StockportGovUK.AspNetCore.Availability.Attributes;

namespace boilerplate.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    [TokenAuthentication]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [FeatureToggle(FeatureToggles.MyToggle)]
        public IActionResult Get()
        {
            return Ok("{'value1': 1, 'value2': 2}");
        }

        [HttpPost]
        [OperationalToggle(OperationalToggles.MyToggle)]
        public IActionResult Post()
        {
            return Ok("{'value1': 1, 'value2': 2}");
        }
    }
}