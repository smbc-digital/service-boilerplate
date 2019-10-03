using System.Threading.Tasks;
using boilerplate.Utils.Toggles;
using Microsoft.AspNetCore.Mvc;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using StockportGovUK.AspNetCore.Availability.Attributes;
using StockportGovUK.AspNetCore.Availability.Managers;

namespace boilerplate.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    [TokenAuthentication]
    [OperationalToggle(OperationalToggles.MyToggle)]
    public class HomeController : ControllerBase
    {
        private IAvailabilityManager _availabilityManager;

        
        public HomeController(IAvailabilityManager availabilityManager)
        {
            _availabilityManager = availabilityManager;
        }

        [HttpGet]
        [FeatureToggle(FeatureToggles.MyToggle)]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [FeatureToggle(FeatureToggles.MyToggle)]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}