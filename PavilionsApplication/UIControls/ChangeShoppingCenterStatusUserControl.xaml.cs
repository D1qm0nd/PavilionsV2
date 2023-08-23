using PavilionsData.PavilionsModel.Context;
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
    /// Логика взаимодействия для ChangeShoppingCenterStatusUserControl.xaml
    /// </summary>
    public partial class ChangeShoppingCenterStatusUserControl : UserControl
    {
        public ShoppingCenter ShoppingCenter
        {
            get => shoppingCenter;
            set
            {
                shoppingCenter = value;
                if (shoppingCenter != null)
                    StatusComboBox.SelectedItem = shoppingCenter.ShoppingCentersStatus;
            }
        }

        private ShoppingCenter shoppingCenter;

        public ChangeShoppingCenterStatusUserControl()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            StatusComboBox.ItemsSource = App.DataBase.Context.ShoppingCentersStatuses.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (StatusComboBox.SelectedItem as ShoppingCentersStatus);
            if (shoppingCenter == null)
            {
                throw new ArgumentNullException(nameof(ShoppingCenter));
            }
            shoppingCenter.ShoppingCentersStatus = value;
            shoppingCenter.Id_ShoppingCenterStatus = value.Id_ShoppingStatus;
            App.DataBase.Context.ShoppingCenters.Update(shoppingCenter);
            App.DataBase.Context.ExecuteSqlCommand("DISABLE TRIGGER CheckShopCenterUpdate ON ShoppingCenters");
            App.DataBase.Context.SaveChanges();
            App.DataBase.Context.ExecuteSqlCommand("ENABLE TRIGGER CheckShopCenterUpdate ON ShoppingCenters");
        }
    }
}
