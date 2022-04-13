using DesktopUI.ViewModels;
using Prism.Services.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;
using Prism.Ioc;

namespace DesktopUI.Commands
{
    public class ShowUpdateProductPanelCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;
        private readonly IDialogService _dialogService;

        public ShowUpdateProductPanelCommand(ProductsViewViewModel viewModel, IDialogService dialogService)
        {
            _viewModel = viewModel;
            _dialogService = dialogService;
        }

        public ShowUpdateProductPanelCommand()
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
            switch (_viewModel.UpdateProductPanelVisibilityMode)
            {
                case Visibility.Collapsed:
                    {
                        if (_viewModel.SelectedProduct == null)
                        {
                            string message = "Please first select any product to update.";
                            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r => { });
                            break;
                        }
                        
                        _viewModel.UpdateProductPanelVisibilityMode = Visibility.Visible;
                        break;
                    }

                default:
                    _viewModel.UpdateProductPanelVisibilityMode = Visibility.Collapsed;
                    break;
            }
        }
    }
}
