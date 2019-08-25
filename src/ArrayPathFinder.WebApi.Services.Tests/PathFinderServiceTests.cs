using System.Collections.Generic;
using ArrayPathFinder.WebApi.Contracts.Response;
using NUnit.Framework;

namespace ArrayPathFinder.WebApi.Services.Tests
{
    public class PathFinderServiceTests
    {
        private readonly IPathCalculationService _service;

        public PathFinderServiceTests()
        {
            _service = new PathCalculationService();
        }

        [Test]
        [TestCaseSource(nameof(CalculatingPathTestCases))]
        public void Given_ItemsArray_When_CalculatingPath_Expect_CorrectResult(List<int> items, bool pathExists, List<TraverseStep> path)
        {
            ArrayPathCalculationResult calculationResult = _service.CalculatePath(items);

            Assert.That(calculationResult, Is.Not.Null);
            Assert.That(calculationResult.PathExists, Is.EqualTo(pathExists));
            CollectionAssert.AreEqual(items, calculationResult.Items);
            CollectionAssert.AreEqual(path, calculationResult.Path);
        }

        public static IEnumerable<TestCaseData> CalculatingPathTestCases()
        {
            yield return new TestCaseData(new List<int>(), false, new List<TraverseStep>());

            yield return new TestCaseData(new List<int> { 1, 2, 0, 3, 0, 2, 0 }, true, new List<TraverseStep>
            {
                new TraverseStep
                {
                    ItemPosition = 0,
                    NextItemPosition = 1
                },
                new TraverseStep
                {
                    ItemPosition = 1,
                    NextItemPosition = 3
                },
                new TraverseStep
                {
                    ItemPosition = 3,
                    NextItemPosition = 6
                }
            });

            yield return new TestCaseData(new List<int> { 1, 2, 0, 1, 0, 2, 0 }, false, new List<TraverseStep>
            {
                new TraverseStep
                {
                    ItemPosition = 0,
                    NextItemPosition = 1
                },
                new TraverseStep
                {
                    ItemPosition = 1,
                    NextItemPosition = 3
                },
                new TraverseStep
                {
                    ItemPosition = 3,
                    NextItemPosition = 4
                }
            });

            yield return new TestCaseData(new List<int> { 3, 5, 2, 4, 0, 0, 0, 1 }, true, new List<TraverseStep>
            {
                new TraverseStep
                {
                    ItemPosition = 0,
                    NextItemPosition = 1
                },
                new TraverseStep
                {
                    ItemPosition = 1,
                    NextItemPosition = 3
                },
                new TraverseStep
                {
                    ItemPosition = 3,
                    NextItemPosition = 7
                }
            });
        }
    }
}