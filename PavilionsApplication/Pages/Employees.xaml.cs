using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Encrypting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using PavilionsData.Extentions;
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

    private void ChangePasswordButton_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int id = -1;
        if (int.TryParse(IdTextBox.Text, out id) == false) return;
        try
        {
            if (CustValidation.PasswordValidation.PasswordValidate(ChangePasswordTextBox.Text) == false)
                throw new ValidationException("Пароль некорректен");
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }

        var employee = App.DataBase.Context.Employees.First(e => e.Id_Employee == id);
        employee.Password = PasswordEncryptor.Encrypt(ChangePasswordTextBox.Text);
        App.DataBase.Context.Employees.Update(employee);
        App.DataBase.Context.SaveChanges();
        UpdateSource();
        IdTextBox.Text = "";
        ChangePasswordTextBox.Visibility = Visibility.Collapsed;
        if (id == App.CurrentEmployee.Id_Employee)
            NavigationService.GoBack();
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        EmployeesDataGrid.ItemsSource =
            App.DataBase.Context.Employees.Where(e => e.Surname.ToLower().Contains((sender as TextBox).Text.ToLower()))
                .ToList();
    }

    private void ChangeRole_OnClick(object sender, RoutedEventArgs e)
    {
        if (ChangeRoleComboBox.Visibility == Visibility.Collapsed)
        {
            ChangeRoleComboBox.ItemsSource = App.DataBase.Context.Roles.GetRoleNames();
            ChangeRoleComboBox.Visibility = Visibility.Visible;
        }
        else
        {
            ChangeRoleComboBox.Visibility = Visibility.Collapsed;
            ChangeRoleComboBox.ItemsSource = null;
        }
    }
    

    private void ChangePasswordTextBox_OnClick(object sender, RoutedEventArgs e)
    {
        if (ChangePasswordTextBox.Visibility == Visibility.Collapsed)
            ChangePasswordTextBox.Visibility = Visibility.Visible;
        else ChangePasswordTextBox.Visibility = Visibility.Collapsed;
    }
    

    private void ChangeRoleComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ChangeRoleComboBox.Visibility == Visibility.Collapsed) return;
        var roleName = ChangeRoleComboBox.SelectedValue.ToString()!;
        int id = -1;
        if (int.TryParse(IdTextBox.Text, out id) == false) return;
        ChangeRole(id, roleName);
        IdTextBox.Clear();
        ChangeRoleComboBox.Visibility = Visibility.Collapsed;
        ChangeRoleComboBox.SelectedValue = null;
        if (id == App.CurrentEmployee.Id_Employee)
            NavigationService.GoBack();
    }

    private void ChangeRole(int id, string roleName)
    {
        var employee = App.DataBase.Context.Employees.GetEmployeeById(id);
        if (employee != null)
        {
            employee.Id_Role = (int)App.DataBase.Context.Roles.GetIdRoleByName(roleName)!;
            App.DataBase.Context.Employees.Update(employee);
            App.DataBase.Context.SaveChanges();
            UpdateSource();
        }
        else
            MessageBox.Show("Пользователь не найден");
    }
}