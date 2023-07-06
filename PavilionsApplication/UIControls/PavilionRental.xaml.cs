using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.PavilionsModel.Context;

namespace PavilionsApplication.UIControls;

public partial class PavilionRental : UserControl
{
    private int Tenant_ID;
    private int ShopCenter_ID;
    private int Pavilion_ID;
    private int Employee_ID;
    
    public PavilionRental()
    {
        InitializeComponent();
    }

    private void TenantsList_OnLoaded(object sender, RoutedEventArgs e)
    {
        foreach (var tenant in App.DataBase.Context.Tenants)
        {
            TenantsList.Items.Add(tenant.Name);
        }
    }

    private void TenantsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Tenant_ID = App.DataBase.Context.Tenants.First(tenant => tenant.Name == TenantsList.SelectedValue).Id_Tenant;
    }


    private void ShopCentersList_OnLoaded(object sender, RoutedEventArgs e)
    {
        foreach (var shoppingCenter in App.DataBase.Context.ShoppingCenters)
        {
            ShopCentersList.Items.Add(shoppingCenter.Name);
        }
    }

    private void ShopCentersList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ShopCenter_ID = App.DataBase.Context.ShoppingCenters.First(sc => sc.Name == ShopCentersList.SelectedValue.ToString())
            .Id_ShoppingCenter;
        foreach (var pavilion in App.DataBase.Context.Pavilions.Where(p =>
                     p.Id_PavilionsStatus == 2 &&
                     p.Id_ShoppingCenter == ShopCenter_ID))
        {
            PavilionsList.Items.Add(pavilion.Number);
        }
        PavilionsList.SelectedValue = "";
        PavilionsList_Loaded();
    }

    private void PavilionsList_Loaded()
    {
        foreach (var pavilion in App.DataBase.Context.Pavilions.Where(pavilion => pavilion.Id_ShoppingCenter == ShopCenter_ID && pavilion.Id_PavilionsStatus == 2))
        {
            PavilionsList.Items.Add(pavilion.Number);
        }
    }

    private void PavilionsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Pavilion_ID = App.DataBase.Context.Pavilions.First(pavilion => pavilion.Number == PavilionsList.SelectedValue.ToString())
            .Id_Pavilion;
    }

    private void EmployeesList_OnLoaded(object sender, RoutedEventArgs e)
    {
        foreach (var employee in App.DataBase.Context.Employees.Where(employee => employee.Id_Role > 1))
        {
            EmployeesList.Items.Add(employee.Surname);
        }
    }

    private void EmployeesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Employee_ID = App.DataBase.Context.Employees.First(employee => employee.Surname == EmployeesList.SelectedValue.ToString()).Id_Employee;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Rent();
    }

    private void Rent()
    {
        try
        {
            App.DataBase.Context.ExecuteSqlCommand("EXEC RentPavilion " +
                                                   $"@PavilionId={Pavilion_ID}," +
                                                   $"@LeaseStart='{StartDatePicker.SelectedDate}', " +
                                                   $"@LeaseEnd='{EndDatePicker.SelectedDate}', " +
                                                   $"@TenantId={Tenant_ID}, " +
                                                   $"@EmpId={Employee_ID}");
            MessageBox.Show("Павильон успешно забронирован");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}