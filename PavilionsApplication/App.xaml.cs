using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using PavilionsApplication.Resources;
using PavilionsData.PavilionsModel.Context;
using SingleTonLib;
using WPFUserControls.Handlers;

namespace PavilionsApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ModifiedContext DataBase = new();

        public static Action<Page> NavigateAppFrame = null;
        
        public static ImageBrush BackGround = new ImageBrush() 
        {
            ImageSource = ImageHandler.GetImage(ResourceFile.Background)
        };

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}