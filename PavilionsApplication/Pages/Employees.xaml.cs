using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PavilionsData.PavilionsModel.Tables;
using WPFUserControls.UserControls;

namespace PavilionsApplication.Pages;

public partial class Employees : Page
{
    public Employees()
    {
        InitializeComponent();
        UpdateSource();
    }

    public void UpdateSource()
    {
        App.DataBase.ReloadContext();
        EmployeesDataGrid.ItemsSource = App.DataBase.Context.Employees.ToList();
    }

    private void UserImage_OnLoaded(object sender, RoutedEventArgs e)
    {
        var bytes = (sender as ImagePicker).Tag as byte[];
        if (bytes != null)
            (sender as ImagePicker).Buffer = bytes;
    }

    private void UserImage_OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        var imagePicker = (sender as ImagePicker);
        imagePicker.Tag = imagePicker.Buffer;
    }

    private void EmployeesDataGrid_OnCurrentCellChanged(object? sender, EventArgs e)
    {
        App.DataBase.Context.Employees.UpdateRange(EmployeesDataGrid.ItemsSource as IEnumerable<Employee>);
        App.DataBase.Context.SaveChanges();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
    }
}