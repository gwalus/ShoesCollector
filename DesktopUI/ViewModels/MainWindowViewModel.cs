using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Mvvm;

namespace DesktopUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IBaseRestClient _restClient;
        private readonly IDialogCoordinator _dialogCoordinator;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
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
