using System;
using System.Collections.Generic;
using System.Text;

namespace Blocktrade
{
    public class User
    {
        public int UserId {  get; set; }
        public string Email { get; set; }
        public TradingAssetAsPrimary PrimaryCurrency { get; set; }
        public string KycStatus { get; set; }
        public string WebsocketAuthToken { get; set; }
        public bool Is2faEnabled { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class TradingAssetAsPrimary
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
