using System.Collections.Generic;

namespace ArrayPathFinder.WebApi.Contracts.Request
{
    /// <summary>
    /// Array of items to pass to request
    /// </summary>
    public class ItemsRequest
    {
        /// <summary>
        /// List of numeric items
        /// </summary>
        public List<int> Items { get; set; }
    }
}