using DesktopUI.ViewModels;
using Domain.Helpers.Enums;
using Domain.Helpers.Filters;
using System;
using System.Windows.Input;
using Prism.Ioc;
using DesktopUI.Interfaces;
using System.Threading.Tasks;

namespace DesktopUI.Commands
{
    public class GetProductsCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public GetProductsCommand(ProductsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var filter = new ProductFilter();

            var totalService = ContainerLocator.Container.Resolve<ITotalService>();

            switch (parameter)
            {
                case nameof(ProductFilterEnum.Available):
                    filter.Condition = nameof(ProductFilterEnum.Available);
                    totalService.SetProductTotalsView(false, filter.Condition);
                    break;

                case nameof(ProductFilterEnum.Sold):
                    filter.Condition = nameof(ProductFilterEnum.Sold);
                    totalService.SetProductTotalsView(true, filter.Condition);
                    break;

                default:
                    filter.Condition = nameof(ProductFilterEnum.All);
                    totalService.SetProductTotalsView(null, filter.Condition);
                    break;
            }
            await _viewModel.GetProducts(filter);
        }

        public event EventHandler CanExecuteChanged;
    }
}