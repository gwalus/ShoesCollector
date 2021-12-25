using DesktopUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class ShowUpdateProductPanelCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public ShowUpdateProductPanelCommand(ProductsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.UpdateProductPanelVisibilityMode == Visibility.Collapsed)
                _viewModel.UpdateProductPanelVisibilityMode = Visibility.Visible;
            else _viewModel.UpdateProductPanelVisibilityMode = Visibility.Collapsed;
        }
    }
}
