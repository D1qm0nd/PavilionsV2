using Microsoft.Identity.Client;
using PavilionsData.PavilionsModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PavilionsApplication.UIControls
{
    /// <summary>
    /// Логика взаимодействия для AddShoppingCenterUserControl.xaml
    /// </summary>
    public partial class AddShoppingCenterUserControl : UserControl
    {

        City city;

        ShoppingCentersStatus status;

        private void Reset()
        {
            city = null;
            status = null;
            Clear();
        }

        public AddShoppingCenterUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            StatusComboBox.ItemsSource = App.DataBase.Context.ShoppingCentersStatuses.ToList();
            CityComboBox.ItemsSource = App.DataBase.Context.Cities.ToList();
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            status = StatusComboBox.SelectedItem as ShoppingCentersStatus;
        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            city = CityComboBox.SelectedItem as City;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sc = Create();

                App.DataBase.Context.ShoppingCenters.Add(sc);
                App.DataBase.Context.SaveChanges();
                MessageBox.Show("ТЦ добавлен", "Информация об операции");
                Reset();
            }
            catch (Exception ex)
            {
                var message = string.Empty;
#if DEBUG
                message = "\nError:\n" + ex.ToString();
#endif
                MessageBox.Show("Не удалось добавить ТЦ" + message, "Fatal error");
            }
        }

        public ShoppingCenter Create()
        {
            try
            {
                if (ShoppingCenterNameTextBox.Text == string.Empty
                    || city == null || status == null
                    //|| PavilionsCountTextBox.Text == string.Empty
                    || FloorsCountTextBox.Text == string.Empty
                    || PriceTextBox.Text == string.Empty
                    || AVCTextBox.Text == string.Empty
                    || PhotoPicker.Buffer == null)
                    throw new ArgumentNullException();
                var sc = new ShoppingCenter
                {
                    Name = ShoppingCenterNameTextBox.Text,
                    Id_ShoppingCenter = App.DataBase.Context.ShoppingCenters.Max(sc => sc.Id_ShoppingCenter)+1,
                    Id_City = city.Id_City,
                    Id_ShoppingCenterStatus = status.Id_ShoppingStatus,
                    FloorsNumber = Int32.Parse(FloorsCountTextBox.Text),
                    Price = double.Parse(PriceTextBox.Text),
                    AddedValueCoefficient = double.Parse(AVCTextBox.Text),
                    Photo = PhotoPicker.Buffer,
                    ShoppingCentersStatus = status,
                    City = city
                };
                //sc.ShoppingCentersStatus = status; //TODO: ??
                return sc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Clear()
        {
            StatusComboBox.SelectedItem = null;
            CityComboBox.SelectedItem = null;
            ShoppingCenterNameTextBox.Clear();
            //PavilionsCountTextBox.Clear();
            FloorsCountTextBox.Clear();
            PriceTextBox.Clear();
            AVCTextBox.Clear();
        }

    }
}
