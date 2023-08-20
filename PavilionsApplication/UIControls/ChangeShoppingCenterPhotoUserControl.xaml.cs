using Microsoft.EntityFrameworkCore;
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
using WPFUserControls.UserControls;

namespace PavilionsApplication.UIControls
{
    /// <summary>
    /// Логика взаимодействия для ChangeShoppingCenterPhotoUserControl.xaml
    /// </summary>
    public partial class ChangeShoppingCenterPhotoUserControl : UserControl
    {
        public ShoppingCenter ShoppingCenter
        {
            get
            {
                return shoppingCenter;
            }
            set
            {
                shoppingCenter = value;
                Picture.Buffer = ShoppingCenter.Photo;
            }
        }

        private ShoppingCenter shoppingCenter = null;

        public ChangeShoppingCenterPhotoUserControl()
        {
            InitializeComponent();
        }

        private void Picture_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (ShoppingCenter != null)
            {
                var bytes = (sender as ImagePicker)!.Buffer;
                if (ShoppingCenter.Photo != bytes)
                {
                    ShoppingCenter.Photo = bytes;
                    App.DataBase.Context.ExecuteSqlCommand("DISABLE TRIGGER CheckShopCenterUpdate ON ShoppingCenters");
                    App.DataBase.Context.ShoppingCenters.Update(shoppingCenter);
                    App.DataBase.Context.SaveChanges();
                    App.DataBase.Context.ExecuteSqlCommand("ENABLE TRIGGER CheckShopCenterUpdate ON ShoppingCenters");
                }
            }
        }
    }
}
