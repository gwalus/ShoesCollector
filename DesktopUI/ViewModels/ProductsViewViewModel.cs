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

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }


        private string _textBoxSearch;
        private readonly IBaseRestClient _restClient;

        public string TextBoxSearch
        {
            get { return _textBoxSearch; }
            set
            {
                _textBoxSearch = value;
                //OnPropertyChanged(nameof(TextBoxSearch));
                //Task.Run(() => GetSearchedProducts(_textBoxSearch)).Wait();
                //GetSearchedProducts(_textBoxSearch);
            }
        }

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