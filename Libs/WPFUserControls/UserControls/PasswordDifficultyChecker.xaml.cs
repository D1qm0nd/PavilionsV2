using Lib.PasswordChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPFUserControls.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PasswordDifficultyChecker.xaml
    /// </summary>
    public partial class PasswordDifficultyChecker : UserControl
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(nameof(Password), null);
            }
        }

        public PasswordDifficultyChecker()
        {
            InitializeComponent();
            PropertyChanged += (_, _) =>
            {
                Difficulty.Content = PasswordChecker.Check(Password);
            };
        }

        public void Check(string password)
        {
            Password = password;
        }


    }
}
