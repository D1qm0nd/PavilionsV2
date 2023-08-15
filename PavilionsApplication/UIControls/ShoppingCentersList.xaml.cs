using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.Extentions;
using PavilionsData.PavilionsModel.Tables;
using WPFUserControls.UserControls;

namespace PavilionsApplication.UIControls;

public partial class ShoppingCentersList : UserControl
{
    public ShoppingCentersList()
    {
        InitializeComponent();
        UpdateSource();
    }

    public void UpdateSource()
    {


        var city = CitiesComboBox.SelectedValue as string;
        var status = StatusesComboBox.SelectedValue as string;

        if (city == null)
        {
            CitiesComboBox.ItemsSource = App.DataBase.Context.Cities
                                             .GetCitiesNames()
                                             .Append(string.Empty)
                                             .OrderBy(c => c).ToList();
        }
        if (status == null)
        {
            StatusesComboBox.ItemsSource = App.DataBase.Context.ShoppingCentersStatuses
                                               .GetShoppingCenterStatusesNames()
                                               .Where(c => c != "Удален")
                                               .Append(string.Empty)
                                               .OrderBy(c => c).ToList();
        }

        if (status != null && city != null && status != string.Empty && city != string.Empty)
        {
            ShopCentersList.ItemsSource = App.DataBase.Context.ShoppingCenters
            .Where(sc => sc.Id_ShoppingCenterStatus != 1
            && sc.ShoppingCentersStatus == App.DataBase.Context.ShoppingCentersStatuses.GetShoppingCenterStatusByName(status)
            && sc.City == App.DataBase.Context.Cities.GetCityByName(city)).OrderBy(c => c.Name).ToList();
        }
        else if (status != null && status != string.Empty)
        {
            ShopCentersList.ItemsSource = App.DataBase.Context.ShoppingCenters
            .Where(sc => sc.Id_ShoppingCenterStatus != 1
            && sc.ShoppingCentersStatus == App.DataBase.Context.ShoppingCentersStatuses.GetShoppingCenterStatusByName(status))
            .OrderBy(c => c.Name).ToList();
        }
        else if (city != null && city != string.Empty)
        {
            ShopCentersList.ItemsSource = App.DataBase.Context.ShoppingCenters
            .Where(sc => sc.Id_ShoppingCenterStatus != 1
            && sc.City == App.DataBase.Context.Cities.GetCityByName(city)).OrderBy(c => c.Name).ToList();
        }
        else
            ShopCentersList.ItemsSource = App.DataBase.Context.ShoppingCenters
                .Where(sc => sc.Id_ShoppingCenterStatus != 1).OrderBy(c => c.Name).ToList();
    }

    private void Picture_OnLoaded(object sender, RoutedEventArgs e)
    {
        var obj = sender as ImagePicker;
        obj!.Buffer = obj.Tag as byte[];
    }

    private void Status_OnLoaded(object sender, RoutedEventArgs e)
    {
        var obj = sender as Label;
        int.TryParse(obj!.Tag.ToString(), out var id);
        if (id == 0) return;
        obj.Content = App.DataBase.Context.ShoppingCentersStatuses.GetShoppingCenterStatusById(id);
    }

    private void PavilionsCount_OnLoaded(object sender, RoutedEventArgs e)
    {
        var obj = sender as Label;
        int.TryParse(obj!.Tag.ToString(), out var id);
        if (id == 0) return;
        obj.Content = App.DataBase.Context.Pavilions.GetShoppingCenterPavilions(id).Count();
    }

    private void City_OnLoaded(object sender, RoutedEventArgs e)
    {
        var obj = sender as Label;
        int.TryParse(obj!.Tag.ToString(), out var id);
        if (id == 0) return;
        var shoppingCenter = App.DataBase.Context.ShoppingCenters.GetShoppingCenterById(id);
        obj.Content = App.DataBase.Context.Cities.GetCityById(shoppingCenter!.Id_City)?.CityName;
    }


    private void ShopCentersList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var list = (sender as ListView);
        if (list.SelectedItem == null) return;
        var id = ((ShoppingCenter)list.SelectedValue).Id_ShoppingCenter;
        var wnd = new Pavilions(id);
        wnd.ShowDialog();
        wnd.Icon = App.Icon;
        wnd.Owner = App.Current.Windows[0];
        list.SelectedItems.Clear();
    }

    private void CitiesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSource();
    }

    private void StatusesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSource();
    }
}