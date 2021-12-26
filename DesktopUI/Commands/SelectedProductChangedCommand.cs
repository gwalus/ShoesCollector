using DesktopUI.ViewModels;
using System;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class SelectedProductChangedCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public SelectedProductChangedCommand(ProductsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.SetProductUpdateModel();
        }
    }
}
