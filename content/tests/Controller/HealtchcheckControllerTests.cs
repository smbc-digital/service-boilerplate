using boilerplate.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace boilerplate_tests.Controllers
{
    public class HealthcheckControllerTests
    {
        private readonly HealthcheckController _valuesController;

        public HealthcheckControllerTests()
        {
            _valuesController = new HealthcheckController();
        }

        [Fact]
        public void Get_ShouldReturnOK()
        {
            // Act
            var response = _valuesController.Get();
            var statusResponse = response as OkObjectResult;
            
            // Assert
            Assert.NotNull(statusResponse);
            Assert.Equal(200, statusResponse.StatusCode);
            Assert.NotNull(statusResponse.Value);
        }
    }
}
