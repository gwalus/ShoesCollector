using DesktopUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using Prism.Ioc;

namespace DesktopUI.Commands
{
    public class ShowAddProductPanelCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public ShowAddProductPanelCommand(ProductsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public ShowAddProductPanelCommand()
        {
            _viewModel = ContainerLocator.Container.Resolve<ProductsViewViewModel>();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddProductPanelVisibilityMode = _viewModel.AddProductPanelVisibilityMode == Visibility.Collapsed 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }
    }
}
