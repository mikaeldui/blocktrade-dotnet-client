using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Blocktrade.Json
{
    internal class BlocktradeJsonSerializerOptions
    {
        private static readonly JsonSerializerOptions _default;

        static BlocktradeJsonSerializerOptions()
        {
            _default = new()
            {
                PropertyNamingPolicy = Chubrik.Json.JsonNamingPolicies.SnakeLowerCase,
            };

            _default.Converters.Add(new TimestampJsonConverter());
        }

        public static JsonSerializerOptions Default => _default;
    }
}
