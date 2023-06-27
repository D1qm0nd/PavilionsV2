using System;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.PavilionsModel.Context;

namespace PavilionsApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PavilionsDbContext Context = new PavilionsDbContext();

        public static Action<Page> NavigateAppFrame = null;

    }
}