using DesktopUI.Commands;

namespace DesktopUI.ViewModels
{
    public class ProductSearchFilterViewModel
    {
        public string Condition { get; set; }

        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private string _size;

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private string _source;

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        public bool? Box { get; set; } = null;

        public SearchProductCommand SearchProductCommand { get; set; }

        public ProductSearchFilterViewModel()
        {
            SearchProductCommand = new SearchProductCommand();
        }
    }
}
