using System.Collections.Generic;

namespace ArrayPathFinder.WebApi.Contracts.Response
{
    /// <summary>
    /// Array path calculation result
    /// </summary>
    public class ArrayPathCalculationResult
    {
        /// <summary>
        /// Original items array passed to request
        /// </summary>
        public List<int> Items { get; set; }
        /// <summary>
        /// Indicates whether path is reachable to the end of items array
        /// </summary>
        public bool PathExists { get; set; }
        /// <summary>
        /// Path on how to traverse the array to the end or where possible (if path doesn't exist)
        /// </summary>
        public List<TraverseStep> Path { get; set; }
    }
}
