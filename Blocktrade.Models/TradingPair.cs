using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class TradingPair
    {
        public int Id { get; set; }
        public int BaseAssetId { get; set; }
        public int QuoteAssetId { get; set; }
        public int DecimalPosition { get; set; }
        /// <summary>
        /// Lot size of the base trading asset
        /// </summary>
        public string LotSize { get; set; }
        public string TickSize { get; set; }
        public string[] RestrictedDirectionsForUser { get; set; }
    }
}
