using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFUserControls.UserControls;

namespace PavilionsApplication.Pages;

public partial class Employees : Page
{
    public Employees()
    {
        InitializeComponent();
        EmployeesDataGrid.ItemsSource = App.Context.Employees.ToList();
    }

    private void UserImage_OnLoaded(object sender, RoutedEventArgs e)
    {
        var bytes = (sender as ImagePicker).Tag as byte[];
        if (bytes != null)
            (sender as ImagePicker).Buffer = bytes;
    }

    private void UserImage_OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
    }
}