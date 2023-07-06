using System;
using System.Windows;
using System.Windows.Controls;
using PavilionsData.PavilionsModel.Context;
using SingleTonLib;

namespace PavilionsApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ModifiedContext DataBase = new();

        public static Action<Page> NavigateAppFrame = null;
    }
}