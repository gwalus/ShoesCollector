using Prism.Mvvm;

namespace DesktopUI.ViewModels
{
    public class ProductTotalViewModel : BindableBase
    {
        private string _description = "Totals:";
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int _quantityTotal;
        public int QuantityTotal
        {
            get { return _quantityTotal; }
            set { SetProperty(ref _quantityTotal, value); }
        }

        private double _purchaseTotal;
        public double PurchaseTotal
        {
            get { return _purchaseTotal; }
            set { SetProperty(ref _purchaseTotal, value); }
        }

        private double _sellTotal;
        public double SellTotal
        {
            get { return _sellTotal; }
            set { SetProperty(ref _sellTotal, value); }
        }

        private double _shipTotal;
        public double ShipTotal
        {
            get { return _shipTotal; }
            set { SetProperty(ref _shipTotal, value); }
        }

        private double _withoutShipTotal;
        public double WithoutShipTotal
        {
            get { return _withoutShipTotal; }
            set { SetProperty(ref _withoutShipTotal, value); }
        }

        private double _profitTotal;
        public double ProfitTotal
        {
            get { return _profitTotal; }
            set { SetProperty(ref _profitTotal, value); }
        }
    }
}
