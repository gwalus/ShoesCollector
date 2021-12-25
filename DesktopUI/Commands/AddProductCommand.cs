using System;
using System.Windows.Input;
using DesktopUI.ViewModels;

namespace DesktopUI.Commands
{
    public class AddProductCommand : ICommand
    {
        private readonly AddProductViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public AddProductCommand(AddProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddProduct(parameter as AddProductViewModel);  
        }
    }
}
