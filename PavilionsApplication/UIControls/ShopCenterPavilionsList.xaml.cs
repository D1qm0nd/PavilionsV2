using System.Collections;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.Extentions;

namespace PavilionsApplication.UIControls;

public partial class ShopCenterPavilionsList : UserControl
{
    public IEnumerable Items
    {
        get => PavilionsDataGrid.ItemsSource;
        set => PavilionsDataGrid.ItemsSource = value;
    }

    public ShopCenterPavilionsList()
    {
        InitializeComponent();
    }


    private void Status_OnLoaded(object sender, RoutedEventArgs e)
    {
        var obj = sender as Label;
        int.TryParse(obj!.Tag.ToString(), out var id);
        if (id == 0) return;
        obj.Content = App.DataBase.Context.PavilionsStatuses.GetPavilionStatusById(id)?.PavilionsStatusName;
    }
}