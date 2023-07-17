using System.Linq;
using System.Windows;
using PavilionsData.Extentions;

namespace PavilionsApplication;

public partial class Pavilions : Window
{
    private readonly int idShoppingCenter;

    public Pavilions(int shoppingCenterId)
    {
        Icon = App.Icon;
        Background = App.BackGround;
        idShoppingCenter = shoppingCenterId;
        InitializeComponent();
        Title = GetTitle();
        UpdateSource();
        RentalUC.ShopCenter_ID = idShoppingCenter;
        AddPavilionUC.IdShoppingCenter = idShoppingCenter;
        
        RentalUC.UpdateSource();

        PavilionsList.PropertyChanged += (_, _) => RentalUC.UpdateSource();
        AddPavilionUC.PropertyChanged += (_, _) => UpdateSource();
    }

    public string? GetTitle() => App.DataBase.Context.ShoppingCenters.GetShoppingCenterById(idShoppingCenter)?.Name;

    public void UpdateSource()
    {
        PavilionsList.Items = App.DataBase.Context.Pavilions.GetShoppingCenterPavilions(idShoppingCenter).Where(_ => _.Id_PavilionsStatus != 1);
    }
}