namespace Blocktrade
{
    public class Trade
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MatchedOrderId { get; set; }
        public int TradingPairId { get; set; }
        /// <summary>
        /// Base asset iso code / quote asset iso code.
        /// </summary>
        public string Symbol { get; set; }
        public string Direction { get; set; }
        /// <summary>
        /// Price for one unit of asset.
        /// </summary>
        public string Price { get; set; }
        public DateTime Date { get; set; }
    }
}
