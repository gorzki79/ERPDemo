using Microsoft.AspNetCore.Mvc;

namespace ERPDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly ILogger<TrucksController> logger;

        public TrucksController(ILogger<TrucksController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrucksAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> GetTruckAsync([FromRoute] string code)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTruckAsync()
        {
            throw new NotImplementedException();
           
        }

        [HttpPut]
        [Route("{truckCode}")]
        public async Task<IActionResult> UpdateTruckAsync(string truckCode)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{truckCode}")]
        public async Task<IActionResult> DeleteTruckAsync(string truckCode)
        {
            throw new NotImplementedException();
        }
    }
}
