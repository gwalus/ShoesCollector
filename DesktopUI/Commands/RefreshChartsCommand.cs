using DesktopUI.ViewModels;
using System;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class RefreshChartsCommand : ICommand
    {
        private readonly ChartsViewViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public RefreshChartsCommand(ChartsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.RefreshChartContent();
        }
    }
}
