﻿namespace Domain.Helpers.Urls
{
    public static class ApiUrl
    {
        public const string BaseApiUrl = "http://localhost:5000/";
        public const string BaseApiProductionUrl = "https://gw-shoes-collector-api.herokuapp.com/";
        public const string API = "api/";

        public const string Products = API + "products";
        public const string Statistics = API + "statistics";
        public const string Totals = API + "totals";
        public const string Brands = API + "brands";
        public const string ProductSources = API + "product-sources";
        public const string Charts = API + "charts-data";

        public const string Product = API + "product";

        public const string FirstPurchase = Statistics + "/first-purchase";
        public const string LatestPurchase = Statistics + "/latest-purchase";
        public const string LatestSale = Statistics + "/latest-sale";

        public const string DaysOfFirstPurchase = Statistics + "/days-of-first-purchase";
        public const string DaysOfLatestPurchase = Statistics + "/days-of-latest-purchase";
        public const string DaysOfLatestSale = Statistics + "/days-of-latest-sale";

        public const string BestProfit = Statistics + "/best-profit";
        public const string LowestProfit = Statistics + "/lowest-profit";
        public const string BiggestPurchase = Statistics + "/biggest-purchase";
        public const string LowestPurchase = Statistics + "/lowest-purchase";

        public const string SoldGroupProductData = Statistics + "/group-sold";
        public const string PurchaseGroupProductData = Statistics + "/group-purchase";
        public const string LossGroupProductData = Statistics + "/group-loss";

        public const string ChartBrands = Charts + "/brands";
        public const string ChartSizes = Charts + "/sizes";
        public const string ChartColor = Charts + "/colors";

        public const string ProductsQuantity = Totals + "/count";
    }
}
