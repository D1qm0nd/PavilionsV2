using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PavilionsData.PavilionsModel.Tables;
using SingleTonLib;

namespace PavilionsApplication.Pages;

public partial class Admin : Page
{
    private Action MoveBack = null;

    public Admin(Employee employee)
    {
        InitializeComponent();
        ViewButton_OnClick(null,null);
        MoveBack = () =>
        {
            NavigationService.GoBack();
        };
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        MoveBack?.Invoke();
    }

    private void ViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        // if (AdminFrame.NavigationService.Content == null)
        // DataFrame.NavigationService.Navigate(Singleton<Employees>.Instance);
        Singleton<Employees>.Instance.UpdateSource();
        DataFrame.NavigationService.Navigate(Singleton<Employees>.Instance);
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        DataFrame.NavigationService.Navigate(Singleton<Register>.Instance);
    }

    private void DataFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
    {
        Type s = sender.GetType();
        if (e.NavigationMode == NavigationMode.Back)
        {
            e.Cancel = true;
            MoveBack?.Invoke();
        }
    }
}