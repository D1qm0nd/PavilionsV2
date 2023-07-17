using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.Extentions;
using PavilionsData.PavilionsModel;
using PavilionsData.PavilionsModel.Context;
using PavilionsData.PavilionsModel.Tables;

namespace PavilionsApplication.UIControls;

public partial class PavilionRental : UserControl
{
    private int Tenant_ID = -1;
    public int ShopCenter_ID { get; set; }
    private int Pavilion_ID = -1;
    private int Employee_ID = App.CurrentEmployee!.Id_Employee;

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
        PavilionsList.ItemsSource = App.DataBase.Context.Pavilions.GetShoppingCenterPavilions(ShopCenter_ID)
            .Where(_ => _.Id_PavilionsStatus != 1)
            .GetPavilionsNumbers();
    }

    private void StatusesList_OnLoaded(object sender, RoutedEventArgs e)
    {
        StatusesList.ItemsSource = App.DataBase.Context.PavilionsStatuses.GetPavilionsStatusNames().Skip(1);
    }

    private void TenantsList_OnLoaded(object sender, RoutedEventArgs e)
    {
        TenantsList.ItemsSource = App.DataBase.Context.Tenants.GetTenantsNames();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (Pavilion_ID == -1 && Tenant_ID == -1 && Employee_ID == -1 && ShopCenter_ID == -1 &&
            StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null)
            return;

        double profit = 0;
        double.TryParse(Profitability.Text, out profit);
        double d_avg = 0;
        double.TryParse(AvgNumberOfVisitsPerDay.Text, out d_avg);
        var avg = (int)Math.Round(d_avg, 0);
        var info = new TenantInfo(kindOfActivity: KindOfActivity.Text, profit,
            avgNumberOfVisitsPerDay: avg);
        App.DataBase.Context.RentPavilion(
            Pavilion_ID,
            Employee_ID,
            Tenant_ID,
            (DateTime)StartDatePicker.SelectedDate!,
            (DateTime)EndDatePicker.SelectedDate!,
            info
        );
        // Rent();
    }

    private void StatusesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        throw new NotImplementedException("При выборе получать статус, и убирать у дополнительных свойств видиость");
    }
}