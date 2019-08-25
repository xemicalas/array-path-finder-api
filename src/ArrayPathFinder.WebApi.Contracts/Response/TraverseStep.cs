namespace ArrayPathFinder.WebApi.Contracts.Response
{
    public class TraverseStep
    {
        public int ItemPosition { get; set; }
        public int NextItemPosition { get; set; }

        public override bool Equals(object obj)
        {
            TraverseStep traverseStep = obj as TraverseStep;

            if (traverseStep == null)
            {
                return false;
            }

            return traverseStep.NextItemPosition == NextItemPosition
                   && traverseStep.ItemPosition == ItemPosition;
        }
    }
}