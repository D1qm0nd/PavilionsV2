using System.Windows.Controls;
using PavilionsData.PavilionsModel.Tables;

namespace PavilionsApplication.Pages;

public partial class Manager_C : Page
{
    public Manager_C(Employee employee)
    {
        Background = App.BackGround;
        InitializeComponent();
    }
}