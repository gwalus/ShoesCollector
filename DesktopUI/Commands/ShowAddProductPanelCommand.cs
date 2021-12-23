﻿using DesktopUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class ShowAddProductPanelCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public ShowAddProductPanelCommand(ProductsViewViewModel viewModel)
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
            if (_viewModel.AddProductPanelVisibilityMode == Visibility.Collapsed)
                _viewModel.AddProductPanelVisibilityMode = Visibility.Visible;
            else _viewModel.AddProductPanelVisibilityMode = Visibility.Collapsed;
        }
    }
}