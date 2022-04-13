using DesktopUI.Commands;
using DesktopUI.Interfaces;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class ChartsViewViewModel : BindableBase
    {
        private readonly IChartService _chartService;

        public ChartsViewViewModel(IChartService chartService)
        {
            _chartService = chartService;

            RefreshChartsCommand = new RefreshChartsCommand(this);

            BrandSeriesCollection = new SeriesCollection();
            SizeSeriesCollection = new SeriesCollection();
            ColorSeriesCollection = new SeriesCollection();

            RefreshChartContent();
        }

        public SeriesCollection BrandSeriesCollection { get; set; }
        public SeriesCollection SizeSeriesCollection { get; set; }
        public SeriesCollection ColorSeriesCollection { get; set; }

        public RefreshChartsCommand RefreshChartsCommand { get; set; }

        public void RefreshChartContent()
        {
            var brandSeries = Task.Run(async () => await _chartService.GetChartBrandSeries()).Result;
            var sizesSeries = Task.Run(async () => await _chartService.GetChartSizesSeries()).Result;
            var colorSeries = Task.Run(async () => await _chartService.GetChartColorSeries()).Result;

            BrandSeriesCollection.Clear();
            SizeSeriesCollection.Clear();
            ColorSeriesCollection.Clear();

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
    }
}
