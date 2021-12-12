using DesktopUI.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Prism.Mvvm;
using System.Collections.Generic;

namespace DesktopUI.ViewModels
{
    public class StatisticsViewViewModel : BindableBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IProductGroupDataService _productGroupDataService;

        private IList<ProductGroupData> _groupedSoldProducts;
        public IList<ProductGroupData> GroupedSoldProducts
        {
            get { return _groupedSoldProducts; }
            set { SetProperty(ref _groupedSoldProducts, value);}
        }

        private IList<ProductGroupData> _groupedPurchaseProducts;
        public IList<ProductGroupData> GroupedPurchaseProducts
        {
            get { return _groupedPurchaseProducts; }
            set { SetProperty(ref _groupedPurchaseProducts, value); }
        }

        //private IList<GroupingData> _groupedLossProducts;

        //public IList<GroupingData> GroupedLossProducts
        //{
        //    get { return _groupedLossProducts; }
        //    set
        //    {
        //        _groupedLossProducts = value;
        //        OnPropertyChanged(nameof(GroupedLossProducts));
        //    }
        //}

        private Product _firstPurchase;

        public Product FirstPurchase
        {
            get { return _firstPurchase; }
            set { SetProperty(ref _firstPurchase, value); }
        }

        private Product _latestPurchase;

        public Product LatestPurchase
        {
            get { return _latestPurchase; }
            set { SetProperty(ref _latestPurchase, value); }
        }

        private Product _latestSale;

        public Product LatestSale
        {
            get { return _latestSale; }
            set { SetProperty(ref _latestSale, value); }
        }

        private int _daysOfFirstPurchase;
        public int DaysOfFirstPurchase
        {
            get { return _daysOfFirstPurchase; }
            set { SetProperty(ref _daysOfFirstPurchase, value); }
        }

        private int _daysOfLatestPurchase;
        public int DaysOfLatestPurchase
        {
            get { return _daysOfLatestPurchase; }
            set { SetProperty(ref _daysOfLatestPurchase, value); }
        }

        private int _daysOfLatestSale;
        public int DaysOfLatestSale
        {
            get { return _daysOfLatestSale; }
            set { SetProperty (ref _daysOfLatestSale, value); }
        }

        private double _bestProfit;

        public double BestProfit
        {
            get { return _bestProfit; }
            set { SetProperty (ref _bestProfit, value); }
        }

        private double _lowestProfit;
        public double LowestProfit
        {
            get { return _lowestProfit; }
            set { SetProperty (ref _lowestProfit, value); }
        }

        private double _biggestPurchase;
        public double BiggestPurchase
        {
            get { return _biggestPurchase; }
            set { SetProperty (ref _biggestPurchase, value); }
        }

        private double _lowestPurchase;
        public double LowestPurchase
        {
            get { return _lowestPurchase; }
            set { SetProperty (ref _lowestPurchase, value);}
        }

        //#region Commands
        //public RefreshStatisticsCommand RefreshStatisticsCommand { get; set; }
        //#endregion

        public StatisticsViewViewModel(IStatisticsService statisticsService, IProductGroupDataService productGroupDataService)
        {
            _statisticsService = statisticsService;
            _productGroupDataService = productGroupDataService;
            //_dataRepository = dataRepository;
            //_statisticsService = statisticsService;
            //RefreshStatisticsCommand = new RefreshStatisticsCommand(this);

            //GroupedSoldProducts = new List<GroupingData>();
            //GroupedPurchaseProducts = new List<GroupingData>();
            //GroupedLossProducts = new List<GroupingData>();

            SetStatistisc();
            SetGroupedProductStatistics();
        }

        private async void SetGroupedProductStatistics()
        {
            GroupedSoldProducts = await _productGroupDataService.GetProductSoldGroupData();
            GroupedPurchaseProducts = await _productGroupDataService.GetProductPurchaseGroupData();

            //var groupedSoldLossProducts = products
            //    .Where(x => x.IsSold && x.Profit < 0)
            //    .OrderByDescending(x => DateTime.Parse(x.SaleDate))
            //    .GroupBy(x => new { DateTime.Parse(x.SaleDate).Year, DateTime.Parse(x.SaleDate).Month })
            //    .ToList();

            //foreach (var item in groupedSoldLossProducts)
            //{
            //    var groupedData = new GroupingData()
            //    {
            //        Year = item.Key.Year,
            //        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
            //        Count = item.Count(),
            //        Purchase = Math.Round(item.Sum(x => x.Profit.Value), 2),
            //        Average = Math.Round((item.Sum(x => x.Profit.Value) / item.Count()), 2)
            //    };

            //    GroupedLossProducts.Add(groupedData);
            //}
        }

        private async void SetStatistisc()
        {
            FirstPurchase = await _statisticsService.GetFirstPurchase();
            LatestPurchase = await _statisticsService.GetLatestPurchase();
            LatestSale = await _statisticsService.GetLatestSale();
            DaysOfFirstPurchase = await _statisticsService.GetDaysOfFirstPurchase();
            DaysOfLatestPurchase = await _statisticsService.GetDaysOfLatestPurchase();
            DaysOfLatestSale = await _statisticsService.GetDaysOfLatestSale();
            BestProfit = await _statisticsService.GetBestProfit();
            LowestProfit = await _statisticsService.GetLowestProfit();
            BiggestPurchase = await _statisticsService.GetBiggestPurchase();
            LowestPurchase = await _statisticsService.GetLowestPurchase();
        }

        public void RefreshContent()
        {
            SetGroupedProductStatistics();
            SetStatistisc();
        }
    }
}