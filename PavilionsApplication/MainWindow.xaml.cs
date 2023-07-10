using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PavilionsApplication.Pages;
using PavilionsApplication.Resources;
using WPFUserControls.Handlers;

namespace PavilionsApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Icon = App.Icon;
            AppIcon.Source = App.Icon;
            AppFrame.Navigate(new Login());
            App.NavigateAppFrame = NavigateApp;
        }

        private void AppFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Forward)
            {
                e.Cancel = true;
            }

            if (e.NavigationMode == NavigationMode.Back)
            {
                App.CurrentEmployee = null;
            }

        }

        private void NavigateApp(Page page)
        {
            AppFrame.Navigate(page);
        }
    }
}