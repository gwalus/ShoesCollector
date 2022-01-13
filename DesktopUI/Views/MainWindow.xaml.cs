using ControlzEx.Theming;
using MahApps.Metro.Controls;

namespace DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        string _mode = "Light.Taupe";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleSwitch_Toggled(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (_mode)
            {
                case "Light.Taupe":
                    ThemeManager.Current.ChangeTheme(this, "Dark.Taupe");
                    _mode = "Dark.Taupe";
                    break;
                case "Dark.Taupe":
                    ThemeManager.Current.ChangeTheme(this, "Light.Taupe");
                    _mode = "Light.Taupe";
                    break;
                default:
                    break;
            }
        }
    }
}
