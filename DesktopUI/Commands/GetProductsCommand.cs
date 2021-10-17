using DesktopUI.ViewModels;
using System;
using System.Windows.Input;

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

        public void Execute(object parameter)
        {
            _viewModel.GetProducts();
        }

        public event EventHandler CanExecuteChanged;
    }
}