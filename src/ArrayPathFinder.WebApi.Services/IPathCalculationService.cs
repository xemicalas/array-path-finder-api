using System.Collections.Generic;
using ArrayPathFinder.WebApi.Contracts.Response;

namespace ArrayPathFinder.WebApi.Services
{
    public interface IPathCalculationService
    {
        ArrayPathCalculationResult CalculatePath(List<int> items);
    }
}