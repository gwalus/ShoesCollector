using ControlzEx.Theming;
using MahApps.Metro.Controls;

namespace DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeTheme(object sender, System.Windows.RoutedEventArgs e)
        {
            var toggleButton = (sender as ToggleSwitch);

            switch (toggleButton.IsOn)
            {
                case true:                
                    ThemeManager.Current.ChangeTheme(this, "Dark.Taupe");
                    break;                                    
                default:
                    ThemeManager.Current.ChangeTheme(this, "Light.Taupe");
                    break;
            }
        }

        //private void ChangeDbMode(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    string isProductionMode = App.Current.Properties["IsProductionMode"].ToString();
        //    if (isProductionMode == "1")
        //        App.Current.Properties["IsProductionMode"] = "0";
        //    else App.Current.Properties["IsProductionMode"] = "1";
        //}
    }
}
