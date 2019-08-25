using System.Collections.Generic;

namespace ArrayPathFinder.WebApi.Contracts.Response
{
    public class ArrayPathCalculationResult
    {
        public List<int> Items { get; set; }
        public bool PathExists { get; set; }
        public List<TraverseStep> Path { get; set; }
    }
}
