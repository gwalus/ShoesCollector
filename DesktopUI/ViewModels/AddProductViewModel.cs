using AutoMapper;
using DesktopUI.Commands;
using DesktopUI.Interfaces;
using DesktopUI.ViewModelDtos;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class AddProductViewModel : BindableBase
    {
        private readonly IBrandService _brandService;
        private readonly IProductSourceService _productSourceService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private string _header;

        public string Header
        {
            get { return _header; }
            set 
            {
                SetProperty(ref _header, value);
            }
        }

        private List<string> _brands;
        public List<string> Brands
        {
            get { return _brands; }
            set
            {
                SetProperty(ref _brands, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {                
                SetProperty(ref _name, value);
            }
        }        

        private string _productCode;
        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                SetProperty(ref _productCode, value.ToUpper());
            }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                SetProperty(ref _color, value);
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                SetProperty(ref _size, value);
            }
        }

        private bool _box;
        public bool Box
        {
            get { return _box; }
            set
            {
                SetProperty(ref _box, value);
            }
        }

        private List<string> _sources;

        public List<string> Sources
        {
            get { return _sources; }
            set
            {
                SetProperty(ref _sources, value);
            }
        }

        private DateTime _dateOfPurchase = DateTime.Today;
        public DateTime DateOfPurchase
        {
            get { return _dateOfPurchase; }
            set
            {
                SetProperty(ref _dateOfPurchase, value);
            }
        }

        private DateTime? _saleDate = null;
        public DateTime? SaleDate
        {
            get { return _saleDate; }
            set
            {
                SetProperty(ref _saleDate, value);
            }
        }

        private double _purchasePrice = 100.00;        
        public double PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                SetProperty(ref _purchasePrice, value);
            }
        }

        private double? _sellingPrice = null;
        public double? SellingPrice
        {
            get { return _sellingPrice; }
            set
            {
                SetProperty(ref _sellingPrice, value);
            }
        }

        private double? _shippingPrice = null;
        public double? ShippingPrice
        {
            get { return _shippingPrice; }
            set
            {
                SetProperty(ref _shippingPrice, value);
            }
        }

        private string _selectedBrand;

        public string SelectedBrand
        {
            get { return _selectedBrand; }
            set 
            { 
                SetProperty(ref _selectedBrand, value);
            }
        }

        private string _selectedProductSource;

        public string SelectedProductSource
        {
            get { return _selectedProductSource; }
            set 
            {
                SetProperty(ref _selectedProductSource, value);
            }
        }

        private string _buttonContent;

        public string ButtonContent
        {
            get { return _buttonContent; }
            set 
            {
                SetProperty(ref _buttonContent, value);
            }
        }

        public AddProductCommand AddProductCommand { get; set; }

        public AddProductViewModel(IBrandService brandService, IProductSourceService productSourceService, IProductService productService, IMapper mapper)
        {
            _brandService = brandService;
            _productSourceService = productSourceService;
            _productService = productService;
            _mapper = mapper;

            AddProductCommand = new AddProductCommand(this);
            
            SetModel();
        }

        private void SetModel()
        {
            Brands = Task.Run(async () =>  await _brandService.GetBrandAsync()).Result.Select(x => x.Name).ToList();
            Sources = Task.Run(async () => await _productSourceService.GetProductSourcesAsync()).Result.Select(x => x.Name).ToList();
        }

        internal async void AddProduct(AddProductViewModel addProductViewModel)
        {
            var productToAdd = _mapper.Map<ProductApiToAdd>(addProductViewModel);

            await _productService.AddProductAsync(productToAdd);
        }
    }
}
