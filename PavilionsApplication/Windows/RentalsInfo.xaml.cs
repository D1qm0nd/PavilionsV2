using PavilionsData.Extentions;
using PavilionsData.PavilionsModel;
using PavilionsData.PavilionsModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using WPFUserControls.UserControls;

namespace PavilionsApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для RentalsInfo.xaml
    /// </summary>
    public partial class RentalsInfo : Window
    {
        private static int? ID_Tenant = null;

        public RentalsInfo()
        {
            this.Icon = App.Icon;
            this.Background = App.BackGround;
            InitializeComponent();
        }

        private void TenantsCombox_Loaded(object sender, RoutedEventArgs e)
        {
            var names = App.DataBase.Context.Tenants.ToList().GetTenantsNames();
            TenantsCombox.ItemsSource = names;
            TenantsCombox.SelectedItem = TenantsCombox.Items.GetItemAt(0);
        }

        private void TenantsCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox).SelectedValue;

            if (value != null)
            {
                ID_Tenant = App.DataBase.Context.Tenants.GetTenantByName((string)value)?.Id_Tenant ?? null;
            }

            RentalsInfoList.ItemsSource = App.DataBase.Context.Rentals.Where(rental => rental.Id_Tenant == ID_Tenant).ToList();

        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Label);
            Pavilion? pav = App.DataBase.Context.Pavilions.FirstOrDefault(pav => pav.Id_Pavilion == (int)obj.Tag);
            ShoppingCenter? sc = null;
            City? city = null;
            if (pav != null)
            {
                sc = pav.ShoppingCenter;// App.DataBase.Context.ShoppingCenters.FirstOrDefault(sc => sc.Id_ShoppingCenter == pav.Id_ShoppingCenter);
                if (sc != null)
                {
                    city = sc.City;
                }
            }
            obj.Content =
                $"Город:\n{city.CityName ?? "Информация отсутствует"}" + Environment.NewLine +
                $"Тогровый центр:\n{sc?.Name ?? "Информация отсутствует"}" + Environment.NewLine +
                $"Номер павилиона:\n{pav?.Number ?? "Информация отсутствует"}" + Environment.NewLine;
        }

        private void Label_Loaded_1(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Label);
            TenantInfo? info = null;
            if (obj.Tag != null)
            {
                info = JsonSerializer.Deserialize<TenantInfo>(((string)obj.Tag)) ?? null;
            }
            var keyValuePair = info?.GetPropertyValues();

            if (keyValuePair != null)
            {
                foreach (var kvp in keyValuePair)
                {
                    obj.Content += kvp.Key + ": " + (GetValue(kvp.Value) ?? "Информация отсутствует") + Environment.NewLine;
                }
            }
            else obj.Content = "Информация отсутствует";
        }

        private string? GetValue(object obj)
        {
            try
            {
                var type = obj.GetType();
                if (type.IsGenericType)
                {
                    var values = string.Empty;
                    foreach (var value in obj as IEnumerable<string>)
                    {
                        values += "\n- " + value;
                    }
                    return values;
                }
                else return obj.ToString();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                return null;
            }
        }

        private void ImagePicker_Loaded(object sender, RoutedEventArgs e)
        {
            var obj = (sender as ImagePicker);
            var pav = App.DataBase.Context.Pavilions.FirstOrDefault(pav => pav.Id_Pavilion == (int)obj.Tag);
            if (pav != null)
                if (pav.ShoppingCenter != null)
                    if ((byte[])pav.ShoppingCenter.Photo != null)
                        obj.Buffer = (byte[])pav.ShoppingCenter.Photo;
        }
    }
}
