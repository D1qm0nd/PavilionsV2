using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

    public Action? UpdateActions { get; set; }

    private int Pavilion_New_Status_ID { get; set; } = -1;

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

    private void PavilionsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var val = (string)PavilionsList.SelectedValue;
        if (val != null)
            Pavilion_ID = App.DataBase.Context.Pavilions.First(p => p.Number == val && p.Id_ShoppingCenter == ShopCenter_ID).Id_Pavilion;
    }

    private void StatusesList_OnLoaded(object sender, RoutedEventArgs e)
    {
        StatusesList.ItemsSource = App.DataBase.Context.PavilionsStatuses.GetPavilionsStatusNames();
    }

    private void TenantsList_OnLoaded(object sender, RoutedEventArgs e)
    {
        TenantsList.ItemsSource = App.DataBase.Context.Tenants.GetTenantsNames();
    }



    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (Pavilion_New_Status_ID > 2)
        {
            if (Pavilion_ID == -1 && Tenant_ID == -1 && Employee_ID == -1 && ShopCenter_ID == -1 &&
                StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null)
                return;
            //double profit = 0;
            //double.TryParse(Profitability.Text, out profit);
            //double d_avg = 0;
            //double.TryParse(AvgNumberOfVisitsPerDay.Text, out d_avg);
            //var avg = (int)Math.Round(d_avg, 0);

            var info = new TenantInfo();

            info.Id = Tenant_ID;
            info.Licence = this.Licence.Text;
            info.KindOfActivity = this.KindOfActivity.Text;
            info.Organization = this.Organization.Text;

            foreach (var item in this.ServiceList.Items)
            {
                info.ServiceList.Add(item as string);
            }

            try
            {
                App.DataBase.Context.RentPavilion(Pavilion_ID, info, Employee_ID, Pavilion_New_Status_ID - 1,
                    (DateTime)StartDatePicker.SelectedDate!,
                    (DateTime)EndDatePicker.SelectedDate!);
                App.DataBase.Context.ExecuteSqlCommand($"EXEC ChangePavilionStatus @ID_Pavilion={Pavilion_ID}, @ID_Status={Pavilion_New_Status_ID}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(messageBoxText: exception.Message);
            }
        }
        else
            App.DataBase.Context.ExecuteSqlCommand($"EXEC ChangePavilionStatus @ID_Pavilion={Pavilion_ID}, @ID_Status={Pavilion_New_Status_ID}");
        App.DataBase.ReloadContext();
        UpdateActions?.Invoke();
    }

    private void StatusesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Pavilion_New_Status_ID =
            (int)App.DataBase.Context.PavilionsStatuses.GetIdPavilionStatysByName((string)StatusesList.SelectedValue)!;
        ShowElements();
    }

    public void ShowElements()
    {
        void ChangeVisibility(Visibility visibility)
        {
            TenantsList.Visibility = visibility;
            KindOfActivity.Visibility = visibility;
            ServicePanel.Visibility = visibility;
            Licence.Visibility = visibility;
            Organization.Visibility = visibility;
            StartDatePicker.Visibility = visibility;
            EndDatePicker.Visibility = visibility;
        }

        ChangeVisibility(Pavilion_New_Status_ID <= 2 ? Visibility.Collapsed : Visibility.Visible);
    }

    private void TenantsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Tenant_ID = App.DataBase.Context.Tenants.First(t => t.Name == (string)TenantsList.SelectedValue).Id_Tenant;
    }

    private void ServiceAddButton_Click(object sender, RoutedEventArgs e)
    {
        if (ServiceNameTextBox.Text != string.Empty && ServiceNameTextBox.Text != null)
        {
            bool contains = false;
            foreach (var item in ServiceList.Items)
            {
                contains = (item as string).Equals(ServiceNameTextBox.Text);
                if (contains == true)
                    break;
            }
            if (contains == false)
            {
                ServiceList.Items.Add(ServiceNameTextBox.Text);
            }
        }
    }
}