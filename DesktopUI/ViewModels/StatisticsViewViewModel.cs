using DesktopUI.Interfaces;
using Domain.Entities;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class StatisticsViewViewModel : BindableBase
    {
        private readonly IStatisticsService _statisticsService;

        //#region Fields
        //private readonly IDataRepository _dataRepository;
        //private readonly IStatisticsService _statisticsService;
        //#endregion

        //private IList<GroupingData> groupedSoldProducts;

        //public IList<GroupingData> GroupedSoldProducts
        //{
        //    get { return groupedSoldProducts; }
        //    set
        //    {
        //        groupedSoldProducts = value;
        //        OnPropertyChanged(nameof(GroupedSoldProducts));
        //    }
        //}

        //private IList<GroupingData> groupedPurchaseProducts;

        //public IList<GroupingData> GroupedPurchaseProducts
        //{
        //    get { return groupedPurchaseProducts; }
        //    set
        //    {
        //        groupedPurchaseProducts = value;
        //        OnPropertyChanged(nameof(GroupedPurchaseProducts));

        //    }
        //}

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

        //private int _daysOfLatestSale;

        //public int DaysOfLatestSale
        //{
        //    get { return _daysOfLatestSale; }
        //    set
        //    {
        //        _daysOfLatestSale = value;
        //        OnPropertyChanged(nameof(DaysOfLatestSale));
        //    }
        //}

        //private double _bestProfit;

        //public double BestProfit
        //{
        //    get { return _bestProfit; }
        //    set
        //    {
        //        _bestProfit = value;
        //        OnPropertyChanged(nameof(BestProfit));
        //    }
        //}

        //private double _lowestProfit;

        //public double LowestProfit
        //{
        //    get { return _lowestProfit; }
        //    set
        //    {
        //        _lowestProfit = value;
        //        OnPropertyChanged(nameof(LowestProfit));
        //    }
        //}


        //private double _biggestPurchase;

        //public double BiggestPurchase
        //{
        //    get { return _biggestPurchase; }
        //    set
        //    {
        //        _biggestPurchase = value;
        //        OnPropertyChanged(nameof(BiggestPurchase));
        //    }
        //}

        //private double _lowestPurchase;

        //public double LowestPurchase
        //{
        //    get { return _lowestPurchase; }
        //    set
        //    {
        //        _lowestPurchase = value;
        //        OnPropertyChanged(nameof(LowestPurchase));
        //    }
        //}

        //#region Commands
        //public RefreshStatisticsCommand RefreshStatisticsCommand { get; set; }
        //#endregion

        public StatisticsViewViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            //_dataRepository = dataRepository;
            //_statisticsService = statisticsService;
            //RefreshStatisticsCommand = new RefreshStatisticsCommand(this);

            //GroupedSoldProducts = new List<GroupingData>();
            //GroupedPurchaseProducts = new List<GroupingData>();
            //GroupedLossProducts = new List<GroupingData>();

            //GetGroupingProducts();
            SetStatistisc();
            //Task.Run(() => SetStatistisc());
        }

        private async void GetGroupingProducts()
        {
            //var products = await _dataRepository.GetProducts();

            //var groupedSoldProducts = products
            //    .Where(x => x.IsSold)
            //    .OrderByDescending(x => DateTime.Parse(x.SaleDate))
            //    .GroupBy(x => new { DateTime.Parse(x.SaleDate).Year, DateTime.Parse(x.SaleDate).Month })
            //    .ToList();

            //foreach (var item in groupedSoldProducts)
            //{
            //    var groupedData = new GroupingData()
            //    {
            //        Year = item.Key.Year,
            //        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
            //        Count = item.Count(),
            //        Profit = Math.Round(item.Sum(x => x.Profit.Value), 2),
            //        Average = Math.Round((item.Sum(x => x.Profit.Value) / item.Count()), 2)
            //    };

            //    GroupedSoldProducts.Add(groupedData);
            //}

            //var groupedPurchaseProducts = products
            //    .OrderByDescending(product => DateTime.Parse(product.DateOfPurchase))
            //    .GroupBy(product => new { DateTime.Parse(product.DateOfPurchase).Year, DateTime.Parse(product.DateOfPurchase).Month })
            //    .ToList();

            //foreach (var item in groupedPurchaseProducts)
            //{
            //    var groupedData = new GroupingData()
            //    {
            //        Year = item.Key.Year,
            //        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month),
            //        Count = item.Count(),
            //        Purchase = Math.Round(item.Sum(x => x.PurchasePrice), 2),
            //        Average = Math.Round((item.Sum(x => x.PurchasePrice) / item.Count()), 2)
            //    };

            //    GroupedPurchaseProducts.Add(groupedData);
            //}

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


            //DaysOfLatestSale = await _statisticsService.GetDaysOfLatestSale();

            //BestProfit = await _statisticsService.GetBestProfit();

            //LowestProfit = await _statisticsService.GetLowestProfit();

            //BiggestPurchase = await _statisticsService.GetBiggestPurchase();

            //LowestPurchase = await _statisticsService.GetLowestPurchase();
        }

        public void RefreshContent()
        {
            GetGroupingProducts();
            SetStatistisc();
        }
    }

    public class GroupingData
    {
        public int Year { get; set; }
        public string Month { get; set; }
        public int Count { get; set; }
        public double Purchase { get; set; }
        public double Profit { get; set; }
        public double Average { get; set; }
    }
}