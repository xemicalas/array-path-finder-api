using ArrayPathFinder.WebApi.Contracts.Request;
using ArrayPathFinder.WebApi.Contracts.Response;
using ArrayPathFinder.WebApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ArrayPathFinder.Host.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PathFinderController : ControllerBase
    {
        private readonly IPathCalculationService _service;

        public PathFinderController(IPathCalculationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Checks whether the end of the array is reachable, calculates optimal path of the array 
        /// </summary>
        /// <param name="itemsRequest">Array of items to pass for calculation</param>
        /// <returns></returns>
        [HttpPost("CalculatePath")]
        public ActionResult<ArrayPathCalculationResult> CalculateArrayPath([FromBody] ItemsRequest itemsRequest)
        {
            if (itemsRequest?.Items == null)
            {
                return BadRequest(new { Reason = "BadRequest", Message = "Items cannot be empty." });
            }

            ArrayPathCalculationResult result = _service.CalculatePath(itemsRequest.Items);

            return Ok(result);
        }
    }
}