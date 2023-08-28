using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Blocktrade
{
    public partial class BlocktradeClient
    {
        /// <summary>
        /// Get all available trading assets.
        /// </summary>
        public async Task<TradingAsset[]?> GetTradingAssetsAsync() => await _httpClient.GetFromJsonAsync<TradingAsset[]>("trading_assets", _jsonSerializerOptions);

        /// <summary>
        /// Get all available trading pairs.
        /// </summary>
        public async Task<TradingPair[]?> GetTradingPairsAsync() => await _httpClient.GetFromJsonAsync<TradingPair[]>("trading_pairs", _jsonSerializerOptions);

        /// <summary>
        /// Get order book based on trading pair ID.
        /// </summary>
        /// <param name="tradingPairId">ID of <see cref="TradingPair"/>.</param>
        public async Task<OrderBook?> GetOrderBookAsync(int tradingPairId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<OrderBook>("order_book/" + tradingPairId, _jsonSerializerOptions);
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

    }
}
