﻿using DesktopUI.ViewModels;
using System;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class UpdateProductCommand : ICommand
    {
        private readonly UpdateProductViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateProductCommand(UpdateProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.UpdateProduct();
        }
    }
}
