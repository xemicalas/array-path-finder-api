using ArrayPathFinder.WebApi.Contracts.Request;
using ArrayPathFinder.WebApi.Contracts.Response;
using ArrayPathFinder.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArrayPathFinder.Host.Controllers
{
    [Route("api/[controller]")]
    public class PathFinderController : ControllerBase
    {
        private readonly IPathCalculationService _service;

        public PathFinderController(IPathCalculationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Calculates optimal path of array of items
        /// </summary>
        /// <param name="itemsRequest"></param>
        /// <returns></returns>
        [HttpPost("/calculatePath")]
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