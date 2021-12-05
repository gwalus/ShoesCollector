using DesktopUI.ViewModels;
using System;
using System.Windows.Input;
using Prism.Ioc;
using DesktopUI.Interfaces;
using System.Threading.Tasks;

namespace DesktopUI.Commands
{
    public class SearchProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var productService = ContainerLocator.Container.Resolve<IProductService>();
            ProductSearchFilterViewModel filter = null;

            if (parameter != null)
                filter = parameter as ProductSearchFilterViewModel;

            var filteredProducts = Task.Run(async () => await productService.GetProducts(filter)).Result;

            productService.SetProductView(filteredProducts);
        }
    }
}
