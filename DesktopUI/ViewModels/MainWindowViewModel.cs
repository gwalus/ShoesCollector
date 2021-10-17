using Domain.Entities;
using Domain.Helpers.Settings;
using Domain.Helpers.Urls;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IBaseRestClient _restClient;
        private readonly IDialogCoordinator _dialogCoordinator;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IBaseRestClient restClient, IDialogCoordinator dialogCoordinator)
        {
            _restClient = restClient;
            _dialogCoordinator = dialogCoordinator;
            Task.Run(async () => await DoSomething());            
        }

        private async Task DoSomething()
        {
            var response = await _restClient.CallAsync<List<Product>>(new RestClientSettings
            {
                Endpoint = ApiUrl.Products
            });

            Title = response.FirstOrDefault().Name;
        }
    }
}
