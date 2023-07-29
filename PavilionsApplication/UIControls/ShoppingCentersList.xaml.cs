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
        ShopCentersList.ItemsSource = App.DataBase.Context.ShoppingCenters.Where(sc => sc.Id_ShoppingCenterStatus != 1) .ToList();
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
}