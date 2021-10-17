using DesktopUI.Services;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using RestSharp;
using System.Windows;

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<IBaseRestClient, BaseRestClient>();
            containerRegistry.RegisterInstance<IRestClient>(new RestClient());

            containerRegistry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        }
    }
}
