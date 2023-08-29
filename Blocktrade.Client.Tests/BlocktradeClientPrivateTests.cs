using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blocktrade.Tests
{
    [TestClass]
    public class BlocktradeClientPrivateTests
    {
        public static readonly string? BLOCKTRADE_API_KEY = Environment.GetEnvironmentVariable(nameof(BLOCKTRADE_API_KEY));
        public static readonly string? BLOCKTRADE_API_SECRET = Environment.GetEnvironmentVariable(nameof(BLOCKTRADE_API_SECRET));
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static BlocktradeClient _client;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            if (string.IsNullOrWhiteSpace(BLOCKTRADE_API_KEY) || string.IsNullOrWhiteSpace(BLOCKTRADE_API_SECRET))
                Assert.Inconclusive("Unable to do private tests as API credentals not specified as environment variables BLOCKTRADE_API_KEY and BLOCKTRADE_API_SECRET.");

            _client = new BlocktradeClient(BLOCKTRADE_API_KEY, BLOCKTRADE_API_SECRET);
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            _client?.Dispose();
        }

        [TestMethod]
        public async Task GetUserAsync()
        {
            var user = await _client.GetUserAsync();
            Assert.IsNotNull(user);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(user.Email));
        }

        [TestMethod]
        public async Task GetFeesAsync()
        {
            var fees = await _client.GetFeesAsync();
            Assert.IsNotNull(fees);
            Assert.IsTrue(fees.Any());
            Assert.IsTrue(fees.First().Value.Any());
        }

        [TestMethod]
        public async Task GetOrdersAsync()
        {
            var orders = await _client.GetOrdersAsync();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Data.Any());
        }
    }
}
