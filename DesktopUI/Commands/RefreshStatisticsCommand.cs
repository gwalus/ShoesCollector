using DesktopUI.ViewModels;
using System;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class RefreshStatisticsCommand : ICommand
    {
        private readonly StatisticsViewViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public RefreshStatisticsCommand(StatisticsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.RefreshContent();
        }
    }
}
