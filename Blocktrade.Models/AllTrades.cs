using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class AllTrades
    {
        public Trade[] Data { get; set; }
        /// <summary>
        /// Number of all trades.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Offset of trades to start from.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Number of trades per page.
        /// </summary>
        public int Limit { get; set; }
    }
}
