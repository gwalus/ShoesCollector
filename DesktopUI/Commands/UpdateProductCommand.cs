using DesktopUI.Interfaces;
using DesktopUI.ViewModels;
using Domain.Helpers.Enums;
using Domain.Helpers.Filters;
using Prism.Ioc;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace DesktopUI.Commands
{
    public class UpdateProductCommand : ICommand
    {
        private readonly UpdateProductViewModel _viewModel;
        private readonly ProductsViewViewModel _productViewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateProductCommand(UpdateProductViewModel viewModel)
        {
            _viewModel = viewModel;
            _productViewModel = App.AppContainer.Resolve<ProductsViewViewModel>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await _viewModel.UpdateProduct(parameter as UpdateProductViewModel);

            var totalService = ContainerLocator.Container.Resolve<ITotalService>();
            totalService.SetProductTotalsView(null, nameof(ProductFilterEnum.All));

            await _productViewModel.GetProducts(new ProductFilter());
        }
    }
}
