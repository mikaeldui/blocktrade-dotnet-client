using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blocktrade.Tests
{
    [TestClass]
    public class BlocktradeClientPublicTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static BlocktradeClient _client;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            _client = new BlocktradeClient();
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task GetTradingAssetsAsync()
        {
            var tradingAssets = await _client.GetTradingAssetsAsync();
            Assert.IsNotNull(tradingAssets);
            Assert.IsTrue(tradingAssets.Any());
            Assert.IsTrue(tradingAssets.All(ta => !string.IsNullOrWhiteSpace(ta.FullName)));
        }

        [TestMethod]
        public async Task GetTradingPairsAsync()
        {
            var tradingPairs = await _client.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            Assert.IsTrue(tradingPairs.Any());
            Assert.IsTrue(tradingPairs.All(ta => !string.IsNullOrWhiteSpace(ta.TickSize)));
        }

        [TestMethod]
        public async Task GetOrderBookAsync()
        {
            var tradingPairs = await _client.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            var orderBook = await _client.GetOrderBookAsync(tradingPairs.First());
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
            var orderBook = await _client.GetOrderBookAsync(12345678);
        }

        [TestMethod]
        public async Task GetTickerAsync()
        {
            var tradingPairs = await _client.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            var ticker = await _client.GetTickerAsync(tradingPairs.First());
            Assert.IsNotNull(ticker);
        }

        [TestMethod]
        [ExpectedException(typeof(TickerNotFoundException))]
        public async Task GetTickerNotFoundAsync()
        {
            var orderBook = await _client.GetTickerAsync(12345678);
        }

        [TestMethod]
        public async Task GetTradesAsync()
        {
            var tradingPairs = await _client.GetTradingPairsAsync();
            Assert.IsNotNull(tradingPairs);
            var trades = await _client.GetTradesAsync(tradingPairs.First());
            Assert.IsNotNull(trades);
            Assert.IsNotNull(trades.Data);
            Assert.IsTrue(trades.Data.Any());
        }

        //[TestMethod]
        //[ExpectedException(typeof(OrderBookNotFoundException))]
        //public async Task GetTradesNotFoundAsync()
        //{
        //    using BlocktradeClient blocktradeClient = new();
        //    var orderBook = await blocktradeClient.GetOrderBookAsync(12345678);
        //}
    }
}
