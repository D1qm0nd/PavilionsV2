using System.Windows;
using System.Windows.Controls;

namespace PavilionsApplication.Pages;

public partial class Register : Page
{
    public Register()
    {
        InitializeComponent();
        RegistrationComponent.HideOnRegister = new[] { 1 };
        RegistrationComponent.LockCondition = true;
        RegistrationComponent.MakeRegister = Authorization.Register!;
        RegistrationComponent.SetFunctionalButtonVisibility(Visibility.Collapsed);
    }
}