using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PavilionsApplication.UIControls.UCValidation;
using PavilionsData.Exceptions;
using PavilionsData.Extentions;
using PavilionsData.PavilionsModel.Tables;

namespace PavilionsApplication.UIControls;

public partial class AddPavilionUserControl : UserControl, INotifyPropertyChanged
{
    public int IdShoppingCenter { get; set; }

    public AddPavilionUserControl()
    {
        InitializeComponent();
    }

    public void ClearValue(object sender) => (sender as TextBox).Clear();

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Add();
        }
        catch (RecordExistingException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (ValidationException ex)
        {
            MessageBox.Show("Проверьте корретность введённых данных");
        }
    }

    public void Add()
    {
        double area = 0;
        double price = 0;
        double avc = 0;
        int floor = 0;
        if (Number.Text.NumberValidate() && double.TryParse(Area.Text.Replace(".", ","), out area) &&
            double.TryParse(AVC.Text.Replace(".", ","), out avc) &&
            double.TryParse(Price.Text.Replace(".", ","), out price) &&
            Int32.TryParse(Floor.Text, out floor) && area > 0 && price > 0 && avc > 0 && floor > 0)
        {
            App.DataBase.Context.AddPavilion(new Pavilion(
                0,
                IdShoppingCenter,
                (int)App.DataBase.Context.PavilionsStatuses.GetIdPavilionStatysByName("Свободен")!,
                Number.Text,
                area,
                price,
                avc));
            OnPropertyChanged();
        }
        else 
            throw new ValidationException();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}