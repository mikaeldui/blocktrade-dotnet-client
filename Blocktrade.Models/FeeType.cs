using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class FeeType : Dictionary<string, Fee>
    {
    }

    public class Fee : Dictionary<string, Fee.FeeContent>
    {
        public class FeeContent
        {
            public string? MinFee {  get; set; }
            public string? PercentValue { get; set;}
        }
    }
}
