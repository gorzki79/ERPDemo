using ERPDemo.Application.Queries;
using ERPDemo.Application.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly ILogger<TrucksController> logger;
        private readonly IMediator mediator;

        public TrucksController(ILogger<TrucksController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckInfo>>> GetTrucksAsync([FromQuery] GetTrucksQuery query)
        {
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<ActionResult<IEnumerable<TruckInfo>>> GetTruckAsync([FromRoute] string code)
        {
            var query = new GetTruckQuery(code);
            var result = await this.mediator.Send(query);
            return Ok(result);
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
