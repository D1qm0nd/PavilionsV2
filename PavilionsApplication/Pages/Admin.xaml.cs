using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PavilionsData.PavilionsModel.Tables;
using SingleTonLib;

namespace PavilionsApplication.Pages;

public partial class Admin : Page
{
    public Admin(Employee employee)
    {
        InitializeComponent();
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (AdminFrame.NavigationService.Content == null)
            AdminFrame.NavigationService.Navigate(new Pages.Employees());
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void AdminFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
    {
        if (e.NavigationMode != NavigationMode.Back)
        {
            e.Cancel = true;
        }
    }
}