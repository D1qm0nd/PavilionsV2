using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using WPFUserControls;

namespace PavilionsApplication.Windows;

public partial class Captcha : Window, ICaptcha
{
    private bool result = false;

    public Captcha()
    {
        InitializeComponent();
        CaptchaText.Content = GenerateRandomText();
    }

    public void InputCaptcha()
    {
        this.ShowDialog();
    }

    private void Captcha_OnClosing(object? sender, CancelEventArgs e)
    {
        e.Cancel = !result;
    }

    private void CaptchaButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (UserInput.Text == CaptchaText.Content.ToString())
            this.result = true;
        this.DialogResult = result;
        this.Close();
    }

    private string GenerateRandomText()
    {
        switch (new Random().Next(0, 5))
        {
            case 0:
                return Faker.Address.Country();
            case 1:
                return Faker.Company.Name();
            case 2:
                return Faker.RandomNumber.Next().ToString();
            case 3:
                return Faker.Identification.UKNationalInsuranceNumber();
            case 4:
                return Faker.Phone.Number();
            case 5:
                return Faker.Internet.DomainName();
            default: return "";
        }
    }
}