using Prism.Ioc;
using Prism.Mvvm;

namespace DesktopUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Shoes Collector";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ProductTotalViewModel _productTotals = ContainerLocator.Container.Resolve<ProductTotalViewModel>();
        public ProductTotalViewModel ProductTotals
        {
            get
            {                
                return _productTotals;
            }
            set { SetProperty(ref _productTotals, value); }
        }

        private ProductsViewViewModel _productsViewViewModel;

        public ProductsViewViewModel ProductsViewViewModel
        {
            get { return _productsViewViewModel; }            
            set { SetProperty(ref _productsViewViewModel, value); }
        }

        public MainWindowViewModel(ProductsViewViewModel productsViewViewModel)
        {
            ProductsViewViewModel = productsViewViewModel;
        }
    }
}
