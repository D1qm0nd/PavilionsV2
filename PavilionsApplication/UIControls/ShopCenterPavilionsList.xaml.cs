using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PavilionsData.Extentions;

namespace PavilionsApplication.UIControls;

public partial class ShopCenterPavilionsList : UserControl, INotifyPropertyChanged
{
    public IEnumerable Items
    {
        get => PavilionsDataGrid.ItemsSource;
        set
        {
            PavilionsDataGrid.ItemsSource = value;
            OnPropertyChanged(nameof(PavilionsDataGrid.ItemsSource));
        }
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
        (obj.Parent as Border).Background = ColorByStatusId(id);
    }

    public SolidColorBrush ColorByStatusId(int id)
    {
        switch (id)
        {
            case 2:
                return Brushes.ForestGreen;
            case 3:
                return Brushes.Orange;
            case 4:
                return Brushes.Red;
            default:
                return Brushes.Transparent;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}