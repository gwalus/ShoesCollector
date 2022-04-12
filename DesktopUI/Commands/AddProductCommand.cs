using System;
using System.Windows.Input;
using DesktopUI.ViewModels;
using Domain.Helpers.Filters;
using Unity;
using Prism.Ioc;

namespace DesktopUI.Commands
{
    public class AddProductCommand : ICommand
    {
        private readonly AddProductViewModel _viewModel;
        private readonly ProductsViewViewModel _productViewModel;

        public event EventHandler CanExecuteChanged;

        public AddProductCommand(AddProductViewModel viewModel)
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
            await _viewModel.AddProduct(parameter as AddProductViewModel);
            await _productViewModel.GetProducts(new ProductFilter());
        }
    }
}
