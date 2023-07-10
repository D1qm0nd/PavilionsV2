using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.Extentions;
using PavilionsData.PavilionsModel.Context;

namespace PavilionsApplication.UIControls;

public partial class PavilionRental : UserControl
{
    private int Tenant_ID;
    public int ShopCenter_ID { get; set; }
    private int Pavilion_ID;
    private int Employee_ID;
    public PavilionRental()
    {
        InitializeComponent();
    }

    public void UpdateSource()
    {
        PavilionsList_OnLoaded();
    }

    private void PavilionsList_OnLoaded()
    {
        PavilionsList.ItemsSource = App.DataBase.Context.Pavilions.GetShoppingCenterPavilions(ShopCenter_ID).Where(_ => _.Id_PavilionsStatus != 1)
            .GetPavilionsNumbers();
    }

    private void StatusesList_OnLoaded(object sender, RoutedEventArgs e)
    {
        StatusesList.ItemsSource = App.DataBase.Context.PavilionsStatuses.GetPavilionsStatusNames();
    }

    private void TenantsList_OnLoaded(object sender, RoutedEventArgs e)
    {
        TenantsList.ItemsSource = App.DataBase.Context.Tenants.GetTenantsNames();
    }

    private void PavilionsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void TenantsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void ShopCentersList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException("Не описан элемент аренды авто");
        // Rent();
    }
}
