using DesktopUI.Interfaces;
using DesktopUI.Services;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using RestSharp;
using System.Windows;
using Unity;

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

            containerRegistry.RegisterSingleton<ProductTotalViewModel>();
            containerRegistry.RegisterSingleton<ProductsViewViewModel>();
            containerRegistry.RegisterSingleton<StatisticsViewViewModel>();
            containerRegistry.RegisterSingleton<AddProductViewModel>();

            containerRegistry.RegisterScoped<ITotalService, TotalService>();
            containerRegistry.RegisterScoped<IProductService, ProductService>();
            containerRegistry.RegisterScoped<IStatisticsService, StatisticsService>();
            containerRegistry.RegisterScoped<IProductGroupDataService, ProductGroupDataService>();
            containerRegistry.RegisterScoped<IBrandService, BrandService>();
            containerRegistry.RegisterScoped<IProductSourceService, ProductSourceService>();

            containerRegistry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        }
    }
}
