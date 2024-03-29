﻿using AutoMapper;
using DesktopUI.Helpers;
using DesktopUI.Interfaces;
using DesktopUI.Services;
using DesktopUI.UserControls;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Domain.Interfaces.Clients;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using Prism.Unity;
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
        public static IUnityContainer AppContainer { get; set; }

        protected override Window CreateShell()
        {
            App.Current.Properties["IsProductionMode"] = 1;

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<IBaseRestClient, BaseRestClient>();
            containerRegistry.RegisterInstance<IRestClient>(new RestClient());

            containerRegistry.RegisterInstance(typeof(IMapper), new Mapper(
                new MapperConfiguration(config =>
                {
                    config.AddMaps(typeof(AutoMapperProfiles).Assembly);
                })));

            containerRegistry.RegisterSingleton<ProductTotalViewModel>();
            containerRegistry.RegisterSingleton<ProductsViewViewModel>();
            containerRegistry.RegisterSingleton<StatisticsViewViewModel>();
            containerRegistry.RegisterSingleton<ChartsViewViewModel>();

            containerRegistry.RegisterSingleton<AddProductViewModel>();
            containerRegistry.RegisterSingleton<UpdateProductViewModel>();

            containerRegistry.RegisterScoped<ITotalService, TotalService>();
            containerRegistry.RegisterScoped<IProductService, ProductService>();
            containerRegistry.RegisterScoped<IStatisticsService, StatisticsService>();
            containerRegistry.RegisterScoped<IProductGroupDataService, ProductGroupDataService>();
            containerRegistry.RegisterScoped<IBrandService, BrandService>();
            containerRegistry.RegisterScoped<IProductSourceService, ProductSourceService>();
            containerRegistry.RegisterScoped<IChartService, ChartService>();

            containerRegistry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>("NotificationDialog");

            AppContainer = containerRegistry.GetContainer();
        }
    }
}
