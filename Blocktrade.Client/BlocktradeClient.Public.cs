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
    }
}
