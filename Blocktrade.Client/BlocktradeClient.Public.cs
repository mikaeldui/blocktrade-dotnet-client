using Blocktrade.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Blocktrade
{
    public partial class BlocktradeClient
    {
        /// <summary>
        /// Creates a new anonymous instance of the <see cref="BlocktradeClient"/> that only has access to public APIs.
        /// </summary>
        public BlocktradeClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Get all available trading assets.
        /// </summary>
        public async Task<TradingAsset[]?> GetTradingAssetsAsync() => await _httpClient.GetFromJsonAsync<TradingAsset[]>("trading_assets", BlocktradeJsonSerializerOptions.Default);

        /// <summary>
        /// Get all available trading pairs.
        /// </summary>
        public async Task<TradingPair[]?> GetTradingPairsAsync() => await _httpClient.GetFromJsonAsync<TradingPair[]>("trading_pairs", BlocktradeJsonSerializerOptions.Default);

        /// <summary>
        /// Get order book based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<OrderBook?> GetOrderBookAsync(int tradingPairId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<OrderBook>("order_book/" + tradingPairId, BlocktradeJsonSerializerOptions.Default);
            }
            catch (HttpRequestException ex) when (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
            {
                throw new OrderBookNotFoundException("Order book not found for trading pair ID: " + tradingPairId, ex);
            }
        }

        /// <summary>
        /// Get order book based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<OrderBook?> GetOrderBookAsync(TradingPair tradingPair) => await GetOrderBookAsync(tradingPair.Id);

        /// <summary>
        /// Get ticker based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<Ticker?> GetTickerAsync(int tradingPairId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Ticker>("ticker/" + tradingPairId, BlocktradeJsonSerializerOptions.Default);
            }
            catch (HttpRequestException ex) when (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
            {
                throw new TickerNotFoundException("Last price not found for trading pair ID: " + tradingPairId, ex);
            }
        }

        /// <summary>
        /// Get ticker based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<Ticker?> GetTickerAsync(TradingPair tradingPair) => await GetTickerAsync(tradingPair.Id);


        /// <summary>
        /// Get trades based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<AllTrades?> GetTradesAsync(int tradingPairId, uint offset = OFFSET_DEFAULT, ushort limit = LIMIT_DEFAULT)
        {
            _ensureLimit(limit);

            try
            {
                return await _httpClient.GetFromJsonAsync<AllTrades>($"trades/{tradingPairId}?offset={offset}&limit={limit}", BlocktradeJsonSerializerOptions.Default);
            }
            catch (HttpRequestException ex) when (ex.Message == "Response status code does not indicate success: 404 (Not Found).")
            {
                throw new TickerNotFoundException("Trades not found for trading pair ID: " + tradingPairId, ex);
            }
        }

        /// <summary>
        /// Get trades based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<AllTrades?> GetTradesAsync(TradingPair tradingPair, uint offset = OFFSET_DEFAULT, ushort limit = LIMIT_DEFAULT) => await GetTradesAsync(tradingPair.Id, offset, limit);
    }
}
