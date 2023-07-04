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
            Icon = ImageHandler.GetImage(ResourceFile.Icon);
            AppIcon.Source = Icon;
            AppFrame.Navigate(new Login());
            App.NavigateAppFrame = NavigateApp;
        }
        
        private void AppFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Forward)
            {
                e.Cancel = true;
            }
        }

        private void NavigateApp(Page page)
        {
            AppFrame.Navigate(page);
        }

    }
}