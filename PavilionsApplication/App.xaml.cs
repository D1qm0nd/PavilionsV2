using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PavilionsApplication.Resources;
using PavilionsData.PavilionsModel.Tables;
using PavilionsData.Exceptions;
using WPFUserControls.Handlers;
using System.Configuration;

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

        public static BitmapImage Icon { get; } = ImageHandler.GetImage(ResourceFile.Icon);

        public static Employee? CurrentEmployee { get; set; } = null;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            try
            {
                DataBase = new();
            }
            catch (Exception ex)
            {
                var message = "Ошибка подключения к базе данных";
#if DEBUG
                message += "\nExceptiong:\n" + ex.ToString();
#endif
                MessageBox.Show(message, "Fatal error");
                this.Dispatcher.InvokeShutdown();
            }
        }
    }
}