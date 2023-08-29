using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class UserOrders : PaginatedResult<UserOrder>
    {
    }

    public class UserOrder
    {
        public int Id { get; set; }
        public string CustomerOrderId { get; set; }
        public int PortfolioId { get; set; }
        public int TradingPairId{ get; set; }
        public string Direction { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string RemainingAmount{ get; set; }
        public string Price { get; set; }
        public string TimeInForce { get; set; }
        public string StopPrice { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public OrderTrade[] Trades { get; set; }
    }
}
