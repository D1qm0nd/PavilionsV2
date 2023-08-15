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

    public Action UpdateActions { get; set; }

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
            MapProperties(this, brdr, info);

            try
            {
                App.DataBase.Context.RentPavilion(Pavilion_ID, info, Employee_ID, Pavilion_New_Status_ID - 1,
                    (DateTime)StartDatePicker.SelectedDate!,
                    (DateTime)EndDatePicker.SelectedDate!);
            }
            catch (Exception exception)
            {
                MessageBox.Show(messageBoxText: exception.Message);
            }
        }
        else
            App.DataBase.Context.ExecuteSqlCommand($"EXEC ChangePavilionStatus @ID_Pavilion={Pavilion_ID}, @ID_Status={Pavilion_New_Status_ID}");
        App.DataBase.ReloadContext();
        UpdateActions();
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
            ServiceList.Visibility = visibility;
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

    private static void MapProperties(object pr, object source, object destination)
    {
        throw new NotImplementedException();   

        var sourceType = pr.GetType();
        var destType = destination.GetType();

        var child = (source as Border).Child as StackPanel;


        foreach (var destProperty in destType.GetProperties())
        { 
            foreach (UIElement children in child.Children)
            {
                if (children.GetType() == typeof(StackPanel))
                {
                    foreach (UIElement children2 in (children as StackPanel).Children)
                    {
                        if (children2.GetType() == typeof(TextBox))
                        {
                            var item = (children2 as TextBox);
                            if (item.Name == destProperty.Name)
                            {
                                var type = destProperty.PropertyType;
                                var method = sourceType.GetMethod("Map").MakeGenericMethod(new Type[] { type });
                                method.Invoke(source, new object[] { destination, destProperty, item.Text });
                            }
                        }
                        else if (children2.GetType() == typeof(ComboBox))
                        {
                            var item = (children2 as ComboBox);
                            if (item.Name == destProperty.Name)
                            {
                                var type = destProperty.PropertyType;
                                var method = sourceType.GetMethod("Map").MakeGenericMethod(new Type[] { type });
                                method.Invoke(source, new object[] { destination, destProperty, item.Items });
                            }
                        }
                    }
                }
            }
        }

        //var srcProperties = sourceType.GetProperties();
        //var destProperties = destType.GetProperties();

        //foreach (var destProperty in destProperties)
        //{
        //    foreach (var srcProperty in srcProperties)
        //    {
        //        if (srcProperty.Name == destProperty.Name)
        //        {
        //            var type = destProperty.PropertyType;
        //            var method = sourceType.GetMethod("Map").MakeGenericMethod(new Type[] { type });
        //            method.Invoke(source, new object[] { destination, destProperty, srcProperty.GetValue(source) });
        //            //Map<destProperty.PropertyType>(destProperty, srcProperty.GetValue(source, null));
        //        }
        //    }
        //}
    }

    private static void Map<T>(object dest, PropertyInfo destinationPropInfo, object BoxValue) where T : Type
    {
        if (BoxValue.GetType() == typeof(TextBox))
        {
            var value = (BoxValue as TextBox).Text;
            try
            {
                if (destinationPropInfo.PropertyType == typeof(double))
                {
                    double val = double.Parse(value.ToString());
                    destinationPropInfo.SetValue(dest, val);
                }
                else
                if (destinationPropInfo.PropertyType == typeof(int))
                {
                    int val = int.Parse(value.ToString());
                    destinationPropInfo.SetValue(dest, val);
                }
                else
                if (destinationPropInfo.PropertyType == typeof(long))
                {
                    long val = long.Parse(value.ToString());
                    destinationPropInfo.SetValue(dest, val);
                }
                else
                if (destinationPropInfo.PropertyType == typeof(uint))
                {
                    uint val = uint.Parse(value.ToString());
                    destinationPropInfo.SetValue(dest, val);
                }
                else
                if (destinationPropInfo.PropertyType == typeof(ulong))
                {
                    ulong val = ulong.Parse(value.ToString());
                    destinationPropInfo.SetValue(dest, val);
                }
                else destinationPropInfo.SetValue(dest, value);
            }
            catch { }
        }
        else if (BoxValue.GetType() == typeof(ComboBox))
        {
            var box = (BoxValue as ComboBox);
            var list = box.Items as T;
            destinationPropInfo.SetValue(dest, list);
        }
    }
}