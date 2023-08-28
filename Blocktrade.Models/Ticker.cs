using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class Ticker
    {
        public string? LastPrice { get; set; }
        public string? BidPrice { get; set; }
        public string? AskPrice { get; set; }
        /// <summary>
        /// 24h trailing volume.
        /// </summary>
        public string Volume { get; set; }
        /// <summary>
        /// 24h trailing low.
        /// </summary>
        public string? Low { get; set; }
        /// <summary>
        /// 24h trailing high.
        /// </summary>
        public string? High { get; set; }
    }
}
