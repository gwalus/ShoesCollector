using DesktopUI.Interfaces;
using DesktopUI.Services;
using DesktopUI.UserControls;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using Prism.Mvvm;
using RestSharp;
using System.Windows;
using Unity;
using Unity.Injection;

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
            //ViewModelLocationProvider.Register<SearchBarUserControl, ProductSearchFilterViewModel>();

            containerRegistry.RegisterScoped<IBaseRestClient, BaseRestClient>();
            containerRegistry.RegisterInstance<IRestClient>(new RestClient());

            containerRegistry.RegisterSingleton<ProductTotalViewModel>();
            containerRegistry.RegisterSingleton<ProductsViewViewModel>();

            containerRegistry.RegisterScoped<ITotalService, TotalService>();
            containerRegistry.RegisterScoped<IProductService, ProductService>();

            containerRegistry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        }
    }
}
