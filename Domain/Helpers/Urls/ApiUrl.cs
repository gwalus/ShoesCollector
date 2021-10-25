namespace Domain.Helpers.Urls
{
    public static class ApiUrl
    {
        public const string BaseApiUrl = "http://localhost:5000/api/";

        public const string Products = "products";
        public const string Statistics = "statistics";

        public const string FirstPurchase = "/first-purchase";
        public const string LatestPurchase = "/latest-purchase";
        public const string LatestSale = "/latest-sale";

        public const string DaysOfFirstPurchase = "/days-of-first-purchase";
        public const string DaysOfLatestPurchase = "/days-of-latest-purchase";
        public const string DaysOfLatestSale = "/days-of-latest-sale";

        public const string BestProfit = "/best-profit";
        public const string LowestProfit = "/lowest-profit";
        public const string BiggestPurchase = "/biggest-purchase";
        public const string LowestPurchase = "/lowest-purchase";
    }
}
