using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blocktrade.Tests
{
    [TestClass]
    public class BlocktradeClientTests
    {
        [TestMethod]
        public async Task GetTradingAssetsAsync()
        {
            using BlocktradeClient blocktradeClient = new BlocktradeClient();
            var tradingAssets = await blocktradeClient.GetTradingAssetsAsync();
            Assert.IsNotNull(tradingAssets);
            Assert.IsTrue(tradingAssets.Any());
            Assert.IsTrue(tradingAssets.All(ta => string.IsNullOrWhiteSpace(ta.FullName)));
        }
    }
}
