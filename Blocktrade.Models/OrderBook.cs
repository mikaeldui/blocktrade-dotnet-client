using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class OrderBook
    {
        public Order[] Asks { get; set; }
        public Order[] Bids { get; set; }
    }
}
