using DesktopUI.ViewModels;
using Domain.Helpers.Enums;
using Domain.Helpers.Filters;
using System;
using System.Windows.Input;

namespace DesktopUI.Commands
{
    public class GetProductsCommand : ICommand
    {
        private readonly ProductsViewViewModel _viewModel;

        public GetProductsCommand(ProductsViewViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var filter = new ProductFilter();

            if (parameter?.ToString() == nameof(ProductFilterEnum.Available))
                filter.Condition = nameof(ProductFilterEnum.Available);

            if (parameter?.ToString() == nameof(ProductFilterEnum.Sold))
                filter.Condition = nameof(ProductFilterEnum.Sold);

            _viewModel.GetProducts(filter);
        }

        public event EventHandler CanExecuteChanged;
    }
}