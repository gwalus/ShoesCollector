using DesktopUI.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class AddProductViewModel : BindableBase
    {
        //private Product product;
        //public Product Product
        //{
        //    get { return product; }
        //    set
        //    {
        //        product = value;
        //        OnPropertyChanged(nameof(Product));
        //    }
        //}

        private List<string> _brands;

        public List<string> Brands
        {
            get { return _brands; }
            set 
            {
                _brands = value; 
                SetProperty(ref _brands, value);
            }
        }


        //public List<string> ListOfBrands { get; set; }
        //private object brandSelected = StaticLists.listOfBrands.ElementAt(0);
        //public object BrandSelected
        //{
        //    get { return brandSelected; }
        //    set
        //    {
        //        brandSelected = value;
        //        OnPropertyChanged(nameof(BrandSelected));
        //        SetProduct();
        //    }
        //}

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetProperty(ref _name, value);
            }
        }

        private string _productCode;
        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                _productCode = value.ToUpper();
                SetProperty(ref _productCode, value);
            }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                SetProperty(ref _color, value);
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                SetProperty(ref _size, value);
            }
        }

        private bool _box;
        public bool Box
        {
            get { return _box; }
            set
            {
                _box = value;
                SetProperty(ref _box, value);
            }
        }

        private List<string> _sources;

        public List<string> Sources
        {
            get { return _sources; }
            set
            {
                _sources = value;
                SetProperty(ref _sources, value);
            }
        }
        //private object sourceSelected = StaticLists.listOfSources.ElementAt(0);

        //public object SourceSelected
        //{
        //    get { return sourceSelected; }
        //    set
        //    {
        //        sourceSelected = value;
        //        OnPropertyChanged(nameof(SourceSelected));
        //        SetProduct();
        //    }
        //}

        private DateTime _dateOfPurchase = DateTime.Today;
        public DateTime DateOfPurchase
        {
            get { return _dateOfPurchase; }
            set
            {
                _dateOfPurchase = value;
                SetProperty(ref _dateOfPurchase, value);
            }
        }

        private double _purchasePrice = 100.00;
        private readonly IBrandService _brandService;
        private readonly IProductSourceService _productSourceService;

        public double PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                _purchasePrice = value;
                SetProperty(ref _purchasePrice, value);
            }
        }

        public AddProductViewModel(IBrandService brandService, IProductSourceService productSourceService)
        {
            _brandService = brandService;
            _productSourceService = productSourceService;
            SetModel();
        }

        private void SetModel()
        {
            Brands = Task.Run(async () =>  await _brandService.GetBrandAsync()).Result.Select(x => x.Name).ToList();
            Sources = Task.Run(async () => await _productSourceService.GetProductSourcesAsync()).Result.Select(x => x.Name).ToList();
        }
    }
}
