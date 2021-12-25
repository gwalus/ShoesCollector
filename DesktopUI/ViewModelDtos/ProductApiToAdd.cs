namespace DesktopUI.ViewModelDtos
{
    public class ProductApiToAdd
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool? Box { get; set; } = false;
        public string Source { get; set; }
        public string DateOfPurchase { get; set; }
        public string SaleDate { get; set; }
        public double PurchasePrice { get; set; }
        public double? SellingPrice { get; set; } = null;
        public double? ShippingPrice { get; set; } = null;
    }
}
