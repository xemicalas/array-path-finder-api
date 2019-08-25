using System.Collections.Generic;
using ArrayPathFinder.WebApi.Contracts.Response;

namespace ArrayPathFinder.WebApi.Services
{
    public class PathCalculationService : IPathCalculationService
    {
        public ArrayPathCalculationResult CalculatePath(List<int> items)
        {
            bool pathExists = false;

            List<TraverseStep> path = new List<TraverseStep>();

            int currentItemPosition = 0;
            while (currentItemPosition != items.Count - 1)
            {
                int nextItemPosition = FindNextItemPosition(items, currentItemPosition);

                if (nextItemPosition > currentItemPosition)
                {
                    path.Add(new TraverseStep
                    {
                        ItemPosition = currentItemPosition,
                        NextItemPosition = nextItemPosition
                    });
                    currentItemPosition = nextItemPosition;
                }
                else
                {
                    break;
                }
            }

            if (currentItemPosition == items.Count - 1)
            {
                pathExists = true;
            }

            return new ArrayPathCalculationResult
            {
                Items = items,
                PathExists = pathExists,
                Path = path
            };
        }

        private int FindNextItemPosition(List<int> items, int currentItemPosition)
        {
            int newPosition = currentItemPosition;
            int offsetPosition = currentItemPosition;

            int newBiggestItem = 0;

            int steps = items[currentItemPosition];
            while (steps > 0)
            {
                if (++offsetPosition >= items.Count - 1)
                {
                    newPosition = offsetPosition;
                    break;
                }

                int nextPossibleItem = items[offsetPosition];
                if (nextPossibleItem >= newBiggestItem)
                {
                    newBiggestItem = nextPossibleItem;
                    newPosition = offsetPosition;
                }

                steps--;
            }

            return newPosition;
        }

    }
}