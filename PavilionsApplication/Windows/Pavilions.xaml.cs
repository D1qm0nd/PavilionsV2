using System.Linq;
using System.Windows;
using PavilionsData.Extentions;

namespace PavilionsApplication;

public partial class Pavilions : Window
{
    
    private readonly int idShoppingCenter;
    public Pavilions(int shoppingCenterId)
    {
        Background = App.BackGround;
        idShoppingCenter = shoppingCenterId;
        InitializeComponent();
        Title = App.DataBase.Context.ShoppingCenters.GetShoppingCenterById(idShoppingCenter)?.Name;
        PavilionsList.Items = App.DataBase.Context.Pavilions.GetShoppingCenterPavilions(idShoppingCenter);
    }
}