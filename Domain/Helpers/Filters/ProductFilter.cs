namespace Domain.Helpers.Filters
{
    public class ProductFilter
    {
        public string Condition { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool? Box { get; set; } = null;
        public string Source { get; set; }
    }
}
