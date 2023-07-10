using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PavilionsApplication.Resources;
using PavilionsData.PavilionsModel.Tables;
using WPFUserControls.Handlers;

namespace PavilionsApplication.Pages;

public partial class Login : Page
{
    public Login()
    {
        InitializeComponent();
        Background = App.BackGround;
        LoginComponentInitSettings();
    }

    private void LoginComponentInitSettings()
    {
        LoginComponent.SetBackground(Brushes.DeepSkyBlue);
        LoginComponent.HideOnLogin = new[] { 1, 3, 4, 5, 6, 7 };
        LoginComponent.ChangeCondition();
        LoginComponent.LockCondition = true;
        LoginComponent.MakeLogin = Authorization.Login!;
        LoginComponent.SetFunctionalButtonVisibility(Visibility.Collapsed);
        LoginComponent.PropertyChanged += (_, _) =>
        {
            var employee = (LoginComponent.HasLogin as Employee);
            switch (employee!.Id_Role)
            {
                case 4:
                    App.NavigateAppFrame(new Admin(employee));
                    break;
                case 3:
                    App.NavigateAppFrame(new Manager_C(employee));
                    break;
                default:
                    MessageBox.Show("Пользователь отсутствует в системе");
                    break;
            }
            App.CurrentEmployee = employee;
        };
    }
}