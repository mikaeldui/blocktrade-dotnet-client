namespace Blocktrade
{
    public class TradingAsset
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IsoCode { get; set; }
        public Uri IconPath { get; set; }
        public Uri IconPathPng { get; set; }
        public string Color { get; set; }
        public string? Sign { get; set; }
        public string CurrencyType { get; set; }
        public string WinimalWithdrawalAmount { get; set; }
        public string MinimalOrderValue { get; set; }
        public int DecimalPosition { get; set; }
        public string LotSize { get; set; }
        public string[] DepositMethods { get; set; }
        public bool IsRestrictedForUser { get; set; }
        public string[] Tags { get; set; }
        public bool IsFavourite { get; set; }
    }
}