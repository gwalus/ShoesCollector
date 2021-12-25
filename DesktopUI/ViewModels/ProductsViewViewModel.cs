using DesktopUI.Commands;
using Domain.Entities;
using Domain.Helpers.Filters;
using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using Prism.Ioc;

namespace DesktopUI.ViewModels
{
    public class ProductsViewViewModel : BindableBase
    {
        private readonly IDialogCoordinator _dialogCoordinator;

        private Visibility _searchBarVisibilityMode = Visibility.Collapsed;

        public Visibility SearchBarVisibilityMode
        {
            get { return _searchBarVisibilityMode; }
            set { SetProperty(ref _searchBarVisibilityMode, value); }
        }

        private Visibility _addProductPanelVisibilityMode = Visibility.Collapsed;

        public Visibility AddProductPanelVisibilityMode
        {
            get { return _addProductPanelVisibilityMode; }
            set { SetProperty(ref _addProductPanelVisibilityMode, value); }
        }

        private Visibility _updateProductPanelVisibilityMode = Visibility.Collapsed;

        public Visibility UpdateProductPanelVisibilityMode
        {
            get { return _updateProductPanelVisibilityMode; }
            set { SetProperty(ref _updateProductPanelVisibilityMode, value); }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            {
                _selectedProduct = value; 
                SetProperty(ref _selectedProduct, value);
            }
        }

        public ShowSearchBarCommand ShowSearchBarCommand { get; set; }
        public ShowAddProductPanelCommand ShowAddProductPanelCommand { get; set; }
        public ShowUpdateProductPanelCommand ShowUpdateProductPanelCommand { get; set; }

        private ProductSearchFilterViewModel _productSearchFilterViewModel = ContainerLocator.Container.Resolve<ProductSearchFilterViewModel>();
        public ProductSearchFilterViewModel ProductSearchFilterViewModel
        {
            get { return _productSearchFilterViewModel; }
            set { SetProperty(ref _productSearchFilterViewModel, value); }
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private readonly IBaseRestClient _restClient;

        #region Commands
        public GetProductsCommand GetProductsCommand { get; set; }

        //public ShowUpdatingProductPanelCommand ShowUpdatingProductPanelCommand { get; set; }
        //public ShowNewProductPanelCommand ShowNewProductPanelCommand { get; set; }
        
        public SearchProductInGoogleCommand SearchProductInGoogleCommand { get; set; }
        #endregion

        //public TestCommand Test { get; set; }

        private AddProductViewModel _addProductViewModel = ContainerLocator.Container.Resolve<AddProductViewModel>();

        public AddProductViewModel AddProductViewModel
        {
            get
            {
                _addProductViewModel.Header = "Add product";
                _addProductViewModel.ButtonContent = "Add";
                return _addProductViewModel;
            }
            set { SetProperty(ref _addProductViewModel, value); }
        }

        private AddProductViewModel _updateProductViewModel = ContainerLocator.Container.Resolve<AddProductViewModel>();

        public AddProductViewModel UpdateProductViewModel
        {
            get
            {
                _updateProductViewModel.Header = "Update product";
                _updateProductViewModel.ButtonContent = "Update";
                return _updateProductViewModel;
            }
            set { SetProperty(ref _updateProductViewModel, value); }
        }

        public ProductsViewViewModel(IBaseRestClient restClient, IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;
            GetProductsCommand = new GetProductsCommand(this);

            //ShowNewProductPanelCommand = new ShowNewProductPanelCommand(this);
            //ShowUpdatingProductPanelCommand = new ShowUpdatingProductPanelCommand(this);
            //SelectedCellsChanged = new SelectedCellsChanged(this);
            SearchProductInGoogleCommand = new SearchProductInGoogleCommand(this);
            //AddProductViewModel = new AddProductViewModel(this, dataRepository, dialogCoordinator);

            ShowSearchBarCommand = new ShowSearchBarCommand(this);
            ShowAddProductPanelCommand = new ShowAddProductPanelCommand(this);
            ShowUpdateProductPanelCommand = new ShowUpdateProductPanelCommand(this);

            //Test = new TestCommand(this);            

            _restClient = restClient;
        }

        public async void GetProducts(ProductFilter filter)
        {
            var controller = await _dialogCoordinator.ShowProgressAsync(this, "Wait", "Loading products...");
            controller.SetIndeterminate();


            var restClientSettings = new RestClientSettings
            {
                Endpoint = ApiUrl.Products
            };

            if (filter.Condition != null)
            {
                restClientSettings.QueryStringParameters = new Dictionary<string, string>();
                restClientSettings.QueryStringParameters.Add(nameof(filter.Condition), filter.Condition);
            }

            var products = await _restClient.CallAsync<List<Product>>(restClientSettings);

            if (products == null)
            {
                await controller.CloseAsync();
                await _dialogCoordinator.ShowMessageAsync(this, "Error", "Cannot load products");
                return;
            }

            Products = new ObservableCollection<Product>(products);
            await controller.CloseAsync();
        }

        //public void SelectedProductChanged()
        //{
        //    UpdateProductViewModel = new UpdateProductViewModel(this, _dataRepository, _dialogCoordinator, _selectedProduct);
        //}

        public void SearchProductInGoogle(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}