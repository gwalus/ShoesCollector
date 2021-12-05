using DesktopUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class ShowSearchBarCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public ShowSearchBarCommand(ProductsViewViewModel viewModel)
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
            if (_viewModel.SearchBarVisibilityMode == Visibility.Collapsed)
                _viewModel.SearchBarVisibilityMode = Visibility.Visible;
            else _viewModel.SearchBarVisibilityMode = Visibility.Collapsed;
        }
    }
}
