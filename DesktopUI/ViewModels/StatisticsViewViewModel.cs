using DesktopUI.Commands;
using DesktopUI.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using MahApps.Metro.Controls.Dialogs;
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
            set { SetProperty(ref _groupedSoldProducts, value); }
        }

        private IList<ProductGroupData> _groupedPurchaseProducts;
        public IList<ProductGroupData> GroupedPurchaseProducts
        {
            get { return _groupedPurchaseProducts; }
            set { SetProperty(ref _groupedPurchaseProducts, value); }
        }

        private IList<ProductGroupData> _groupedLossProducts;
        public IList<ProductGroupData> GroupedLossProducts
        {
            get { return _groupedLossProducts; }
            set { SetProperty(ref _groupedLossProducts, value); }
        }

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
            set { SetProperty(ref _daysOfLatestSale, value); }
        }

        private double _bestProfit;

        public double BestProfit
        {
            get { return _bestProfit; }
            set { SetProperty(ref _bestProfit, value); }
        }

        private double _lowestProfit;
        public double LowestProfit
        {
            get { return _lowestProfit; }
            set { SetProperty(ref _lowestProfit, value); }
        }

        private double _biggestPurchase;
        public double BiggestPurchase
        {
            get { return _biggestPurchase; }
            set { SetProperty(ref _biggestPurchase, value); }
        }

        private double _lowestPurchase;
        public double LowestPurchase
        {
            get { return _lowestPurchase; }
            set { SetProperty(ref _lowestPurchase, value); }
        }

        public RefreshStatisticsCommand RefreshStatisticsCommand { get; set; }

        public StatisticsViewViewModel(IStatisticsService statisticsService, IProductGroupDataService productGroupDataServices)
        {
            _statisticsService = statisticsService;
            _productGroupDataService = productGroupDataServices;

            RefreshStatisticsCommand = new RefreshStatisticsCommand(this);

            SetStatistisc();
            SetGroupedProductStatistics();
        }

        private async void SetGroupedProductStatistics()
        {
            GroupedSoldProducts = await _productGroupDataService.GetProductSoldGroupData();
            GroupedPurchaseProducts = await _productGroupDataService.GetProductPurchaseGroupData();
            GroupedLossProducts = await _productGroupDataService.GetProductLossGroupData();
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