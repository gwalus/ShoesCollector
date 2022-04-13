using DesktopUI.Interfaces;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class ChartsViewViewModel : BindableBase
    {
        private readonly IChartService _chartService;

        public ChartsViewViewModel(IChartService chartService)
        {
            _chartService = chartService;

            var brandSeries = Task.Run(async () => await _chartService.GetChartBrandSeries()).Result;
            var sizesSeries = Task.Run(async () => await _chartService.GetChartSizesSeries()).Result;
            var colorSeries = Task.Run(async () => await _chartService.GetChartColorSeries()).Result;

            BrandSeriesCollection = new SeriesCollection();
            SizeSeriesCollection = new SeriesCollection();
            ColorSeriesCollection = new SeriesCollection();

            brandSeries.ForEach(x => BrandSeriesCollection.Add(new PieSeries
            {
                Title = x.Name,
                Values = new ChartValues<ObservableValue> { new ObservableValue(x.Count) },
                DataLabels = true,
                FontSize = 16
            }));

            sizesSeries.ForEach(x => SizeSeriesCollection.Add(new PieSeries
            {
                Title = x.Size,
                Values = new ChartValues<ObservableValue> { new ObservableValue(x.Count) },
                DataLabels = true,
                FontSize = 16
            }));

            colorSeries.ForEach(x => ColorSeriesCollection.Add(new PieSeries
            {
                Title = x.Name,
                Values = new ChartValues<ObservableValue> { new ObservableValue(x.Count) },
                DataLabels = true,
                FontSize = 16
            }));
        }

        public SeriesCollection BrandSeriesCollection { get; set; }
        public SeriesCollection SizeSeriesCollection { get; set; }
        public SeriesCollection ColorSeriesCollection { get; set; }
    }
}
