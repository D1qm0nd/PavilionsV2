using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PavilionsApplication.Windows;
using PavilionsData.PavilionsModel.Tables;
using SingleTonLib;

namespace PavilionsApplication.Pages;

public partial class Manager_C : Page
{
    private Action MoveBack = null;

    public Manager_C(Employee employee)
    {
        Background = App.BackGround;
        InitializeComponent();
        MoveBack = () =>
        {
            NavigationService.GoBack();
        };
    }



    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        MoveBack?.Invoke();
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

    private void TenantRentals_Click(object sender, RoutedEventArgs e)
    {
        var wnd = new RentalsInfo();
        wnd.ShowDialog();
    }
}