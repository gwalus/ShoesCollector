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
using DesktopUI.Interfaces;

namespace DesktopUI.ViewModels
{
    public class ProductsViewViewModel : BindableBase
    {        
        private readonly IDialogCoordinator _dialogCoordinator;       
        private bool _addProductPanelVisible;

        public bool AddProductPanelVisible
        {
            get { return _addProductPanelVisible; }
            set
            {
                _addProductPanelVisible = value;
                //OnPropertyChanged(nameof(AddProductPanelVisible));
            }
        }

        private bool _updatingProductPanelVisible;

        public bool UpdatingProductPanelVisible
        {
            get { return _updatingProductPanelVisible; }
            set
            {
                _updatingProductPanelVisible = value;
                //OnPropertyChanged(nameof(UpdatingProductPanelVisible));
            }
        }


        private bool _updateProductPanelVisible;

        public bool UpdateProductPanelVisible
        {
            get { return _updateProductPanelVisible; }
            //set { _updateProductPanelVisible = value; OnPropertyChanged(nameof(UpdateProductPanelVisible)); }
        }

        
        private Visibility _searchBarVisibilityMode = Visibility.Collapsed;

        public Visibility SearchBarVisibilityMode
        {
            get { return _searchBarVisibilityMode; }
            set { SetProperty(ref _searchBarVisibilityMode, value); }
        }


        //public Visibility IsSearchBarVisible { get; set; } = Visibility.Collapsed;

        public ShowSearchBarCommand ShowSearchBarCommand { get; set; }


        #region Properties
        //private Product _selectedProduct;

        //public Product SelectedProduct
        //{
        //    get { return _selectedProduct; }
        //    set
        //    {
        //        _selectedProduct = value;
        //        OnPropertyChanged(nameof(SelectedProduct));
        //    }
        //}

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

        #endregion

        #region Commands
        public GetProductsCommand GetProductsCommand { get; set; }

        //public ShowUpdatingProductPanelCommand ShowUpdatingProductPanelCommand { get; set; }
        //public ShowNewProductPanelCommand ShowNewProductPanelCommand { get; set; }
        //public SelectedCellsChanged SelectedCellsChanged { get; set; }
        public SearchProductInGoogleCommand SearchProductInGoogleCommand { get; set; }        
        #endregion

        //public TestCommand Test { get; set; }


        #region ViewModels
        //private TotalsViewModel totalsViewModel;

        //public TotalsViewModel TotalsViewModel
        //{
        //    get { return totalsViewModel; }
        //    set
        //    {
        //        totalsViewModel = value;
        //        OnPropertyChanged(nameof(TotalsViewModel));
        //    }
        //}

        //public AddProductViewModel AddProductViewModel { get; set; }
        //private UpdateProductViewModel _updateProductViewModel;
        //public UpdateProductViewModel UpdateProductViewModel
        //{
        //    get { return _updateProductViewModel; }
        //    set
        //    {
        //        _updateProductViewModel = value;
        //        OnPropertyChanged(nameof(UpdateProductViewModel));
        //    }
        //}
        #endregion

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

        //private async void GetSearchedProducts(string name)
        //{
        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        var productsSearched = await _dataRepository.SearchProduct(name);

        //        Products = new ObservableCollection<Product>(productsSearched);
        //    }
        //    //else GetProducts();
        //}

        //private void SetTotalsViewModel(List<Product> products)
        //{
        //    TotalsViewModel = new TotalsViewModel(products);
        //}

        //public void SelectedProductChanged()
        //{
        //    UpdateProductViewModel = new UpdateProductViewModel(this, _dataRepository, _dialogCoordinator, _selectedProduct);
        //}

        //public void ShowAddingProductPanel()
        //{
        //    if (AddProductPanelVisible)
        //        AddProductPanelVisible = false;
        //    else AddProductPanelVisible = true;
        //}

        //public void ShowUpdatingProductPanel()
        //{
        //    if (UpdatingProductPanelVisible)
        //        UpdatingProductPanelVisible = false;
        //    else UpdatingProductPanelVisible = true;
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