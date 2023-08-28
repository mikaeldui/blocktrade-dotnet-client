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
            using BlocktradeClient blocktradeClient = new();
            var tradingAssets = await blocktradeClient.GetTradingAssetsAsync();
            Assert.IsNotNull(tradingAssets);
            Assert.IsTrue(tradingAssets.Any());
            Assert.IsTrue(tradingAssets.All(ta => !string.IsNullOrWhiteSpace(ta.FullName)));
        }

        [TestMethod]
        public async Task GetTradingPairsAsync()
        {
            using BlocktradeClient blocktradeClient = new();
            var tradingPairs = await blocktradeClient.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            Assert.IsTrue(tradingPairs.Any());
            Assert.IsTrue(tradingPairs.All(ta => !string.IsNullOrWhiteSpace(ta.TickSize)));
        }

        [TestMethod]
        public async Task GetOrderBookAsync()
        {
            using BlocktradeClient blocktradeClient = new();
            var tradingPairs = await blocktradeClient.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            var orderBook = await blocktradeClient.GetOrderBookAsync(tradingPairs.First());
            Assert.IsNotNull(orderBook);
            Assert.IsNotNull(orderBook.Asks);
            Assert.IsNotNull(orderBook.Bids);
            Assert.IsTrue(orderBook.Asks.Any());
            Assert.IsTrue(orderBook.Bids.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(OrderBookNotFoundException))]
        public async Task GetOrderBookNotFoundAsync()
        {
            using BlocktradeClient blocktradeClient = new();
            var orderBook = await blocktradeClient.GetOrderBookAsync(12345678);
        }
    }
}
