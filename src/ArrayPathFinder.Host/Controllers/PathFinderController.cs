using Microsoft.AspNetCore.Mvc;

namespace ArrayPathFinder.Host.Controllers
{
    [Route("api/[controller]")]
    public class PathFinderController : ControllerBase
    {
        /// <summary>
        /// Calculates optimal path of array of items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost("/calculatePath")]
        public IActionResult CalculateArrayPath([FromBody] int[] items)
        {
            return Ok(10);
        }
    }
}