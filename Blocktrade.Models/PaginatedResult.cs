namespace Blocktrade
{
    public class PaginatedResult<T> where T : class, new()
    {
        public T[] Data { get; set; }
        /// <summary>
        /// Number of all data.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Offset of data to start from.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Number of data per page.
        /// </summary>
        public int Limit { get; set; }
    }
}
