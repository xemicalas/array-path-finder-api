namespace ArrayPathFinder.WebApi.Contracts.Response
{
    /// <summary>
    /// Traverse step
    /// </summary>
    public class TraverseStep
    {
        /// <summary>
        /// Item position from where to start to traverse
        /// </summary>
        public int ItemPosition { get; set; }
        /// <summary>
        /// Next item position to traverse
        /// </summary>
        public int NextItemPosition { get; set; }

        protected bool Equals(TraverseStep other)
        {
            return ItemPosition == other.ItemPosition && NextItemPosition == other.NextItemPosition;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TraverseStep) obj);
        }
    }
}